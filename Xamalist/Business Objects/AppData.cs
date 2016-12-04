using System;
namespace Xamalist
{
    public class AppData
    {
        public AppData()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string IconImageUrl { get; set; }
        public string SourceCodeUrl { get; set; }
        public string StoreUrlIos { get; set; }
        public string StoreUrlAndroid { get; set; }
        public string StoreUrlWindows { get; set; }
        public string StoreUrlMac { get; set; }
        public string CategoryId { get; set; }
        public string ScreenshotImageUrl { get; set; }
        public string AuthorId { get; set; }
        public string AnnoucingArticleUrl { get; set; }
        public string Backend { get; set; }
        public string IsXamarinNative { get; set; }
        public string IsXamarinForms { get; set; }
        public string UsedLibrary { get; set; }
        public string IsVisible { get; set; }
    }
}
