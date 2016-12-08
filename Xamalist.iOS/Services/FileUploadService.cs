using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Xamalist.Services;
using System.IO;
using Plugin.Media.Abstractions;

namespace Xamalist.iOS.Services
{
    public class FileUploadService : IFileUploadService
    {
        public FileUploadService()
        {
        }

        public async Task<Uri> UploadAsync(MediaFile file)
        {

            // Retrieve storage account from connection string.
            var storageAccount = CloudStorageAccount.Parse(Consts.StorageConnectionString);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference("xamalist");

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            // 一意になるようにファイル名をつける
            var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.Path)}";
            // Retrieve reference to a blob named "myblob".
            var blockBlob = container.GetBlockBlobReference(fileName);

            // Create the "myblob" blob with the text "Hello, world!"
            await blockBlob.UploadFromStreamAsync(file.GetStream());

            return blockBlob.Uri;
        }
    }
}
