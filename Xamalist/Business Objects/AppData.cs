using System;
namespace Xamalist
{
    // アプリについての詳細データ。１レコード１アプリ
    public class AppData
    {
        public AppData()
        {
        }

        // 勝手に採番されるID
        public string Id { get; set; }

        // アプリの名前
        public string Name { get; set; }
        // アプリのアイコンの画像URL
        public string IconImageUrl { get; set; }
        // 書いたアプリのソースコード置き場の URL。GitHub など
        public string SourceCodeUrl { get; set; }

        // ストアのURL。iOS/ Android/ Windows/ Mac
        public string StoreUrlIos { get; set; }
        public string StoreUrlAndroid { get; set; }
        public string StoreUrlWindows { get; set; }
        public string StoreUrlMac { get; set; }

        // アプリのカテゴリのID。別テーブル『AppCategory』から引っ張ってくる
        public string CategoryId { get; set; }
        // アプリのスクショの画像URL
        public string ScreenshotImageUrl { get; set; }
        // アプリ制作者のID。別テーブル『Aurthor』から引っ張ってくる
        public string AuthorId { get; set; }
        // 「Xamarinで作ったよ！」というアナウンスをしているブログ記事のURL
        public string AnnoucingArticleUrl { get; set; }
        // バックエンドは何を使ってる？　なし/Azure/AWS/GCS/ etc...
        public string Backend { get; set; }

        // アプリの作りについて。Xamarin Native 製？
        public bool IsXamarinNative { get; set; }
        // アプリの作りについて。Xamarin.Forms 製？
        public bool IsXamarinForms { get; set; }

        // 使ったライブラリについて。Prism/ SkiaSharp etc..
        public string UsedLibrary { get; set; }
        // 内部で持つ情報。表示非表示フラグ
        public bool IsVisible { get; set; }
    }
}
