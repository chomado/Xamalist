using System;
namespace Xamalist
{
    // 「Consts」って rename して使ってください
    public static class Consts_sample
    {
        // 接続先の Webサーバのアドレス
        public static readonly string AzureWebsitesUrl = "https://(サーバーのURL).azurewebsites.net";

        // Azure 上のストレージの接続文字列
        public static readonly string StorageConnectionString = "めっちゃ長い接続文字列。Azureのポータルの「アクセスキー」から取って来てね";

        // Mobile Center の iOSアプリの AppSecret文字列
        public static readonly string MobileCenterAppSecretIos = "そこそこ長い";
        
    }
}
