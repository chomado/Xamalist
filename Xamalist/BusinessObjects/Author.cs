using System;
namespace Xamalist
{
    // アプリ製作者についての情報
    public class Author
    {
        public Author()
        {
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string GitHub { get; set; }
        public string Website { get; set; }
        public string MailAddress { get; set; }
    }
}
