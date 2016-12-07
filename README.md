# Xamalist (ざまりすと)

「Xamarin 製アプリ一覧アプリ」です。    
よく「Xamarinを使ったらどんなアプリが作れるの？」など聞かれるので、欲しいと思ったので作りました！

早く完成させてストアに上げたいなあ

## 始め方

clone したままでは動きません。    
サーバURLを記述した `Xamalist/Commons/Consts.cs` ファイルを gitignore しているので、     
clone したら そのファイルを作ってサーバURLを記述してください。    
(サーバ環境は各自 `Microsoft Azure Mobile Apps` を使い用意していただく必要があります。)

````csharp
using System;
namespace Xamalist
{
    public static class Consts
    {
        // 接続先サーバのURL
        public static readonly string AzureWebsitesUrl = "https://（サーバのURL文字列）.azurewebsites.net";
    }
}
````

