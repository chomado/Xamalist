using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Xamalist.Services
{
    public interface IFileUploadService
    {
        Task<Uri> UploadAsync(MediaFile file);
    }
}
