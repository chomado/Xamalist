using Microsoft.WindowsAzure.MobileServices;
using Prism.Unity;
using Xamalist.Views;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace Xamalist
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

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

            // コンテナに モバイルサービスクライアントを登録
            var client = new MobileServiceClient(mobileAppUri: Consts.AzureWebsitesUrl);
            this.Container.RegisterInstance<IMobileServiceClient>(client);
            // AppData をコンテナに シングルトンで登録
            this.Container.RegisterType<IAppDataService, AppDataService>(new ContainerControlledLifetimeManager());
        }
    }
}

