﻿using Microsoft.WindowsAzure.MobileServices;
using Prism.Unity;
using Xamalist.Views;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Xamalist.Services;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Xamalist
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) 
        { 
            // Mobile Center 用のコード
            MobileCenter.Start(services: new System.Type[] { typeof(Analytics), typeof(Crashes) });
            // クラッシュのデータ収集を有効化する
            Crashes.Enabled = true;
        }

        // アプリのエントリーポイント
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        // コンテナに型を登録するメソッド
        protected override void RegisterTypes()
        {
            this.Container.RegisterTypeForNavigation<MainPage>(); // メモ：ここでコンテナに登録すると、画面遷移の時の URLで使えるようになる
			this.Container.RegisterTypeForNavigation<NavigationPage>();
			this.Container.RegisterTypeForNavigation<DetailPage>(); // 詳細ページも登録
			this.Container.RegisterTypeForNavigation<RegisterPage>(); // 登録ページも登録

            // コンテナに モバイルサービスクライアントを登録
            var client = new MobileServiceClient(mobileAppUri: Consts.MobileCenterDbUrl); //
            //var client = new MobileServiceClient(mobileAppUri: Consts.AzureWebsitesUrl); // Azure

            this.Container.RegisterInstance<IMobileServiceClient>(client);
            // AppData をコンテナに シングルトンで登録
            this.Container.RegisterType<IAppDataService, AppDataService>(new ContainerControlledLifetimeManager());
        }
    }
}

