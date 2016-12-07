# Xamalist (ざまりすと)

「Xamarin 製アプリ一覧アプリ」です。 

よく「Xamarinを使ったらどんなアプリが作れるの？」など聞かれるので、欲しいと思ったので作りました！

![Startup project](./doc_image/app_screenshot.png)

C# だけで、iOS/ Android アプリを作っています。Swift/Obj-C も Java も 1行も書いていません。
UIは XAML(ザムル)というマークアップ言語を使っています。
コードは今のところ iOS/Android間で 9.5割くらい共通化しています。

![XamarinForms](https://blog.xamarin.com/wp-content/uploads/2014/06/XamarinForms1.png)

早く完成させてストアに上げたいなあ

## 使っているもの

### クライアント:

* Xamarin.Forms
* Prism

### サーバサイド:

* Microsoft Azure Mobile Apps

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

