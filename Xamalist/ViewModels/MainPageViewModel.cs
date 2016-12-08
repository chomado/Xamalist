using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamalist.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        /* データをリフレッシュするタイミング
         *  1. 初回表示
         *  2. 登録ページから戻ってきた時
         */
		public MainPageViewModel(IAppDataService appDataService, INavigationService navigationService)
        {
            this.appDataService = appDataService;

            // データを Azure から読み込むコマンド。読み込んでいる間は CanExecute が false を返す
            this.ReadAppDataCommand = new DelegateCommand(
                executeMethod:    async () => await this.ReadAppDataAsync(), 
                canExecuteMethod: () => !this.IsBusy
            )
            .ObservesProperty(propertyExpression: () => this.IsBusy); // IsBusyプロパティを監視し、IsBusyに変化があったら、CanExecuteChangedイベントを発行する

			// 詳細ページへと遷移する時のコマンドを定義
			this.NavigateToDetailCommand = new DelegateCommand<string>(
				executeMethod: async id => await navigationService.NavigateAsync(name: $"DetailPage?id={id}")
			);

            // 登録ページへと遷移する時のコマンドを定義
            this.NavigateToRegisterPageCommand = new DelegateCommand(
                executeMethod: async () => await navigationService.NavigateAsync(name: "RegisterPage")
            );

            // 初回表示時にデータがリフレッシュされる
            this.ReadAppDataAsync();
        }

        private IAppDataService appDataService;
        private IEnumerable<AppData> appDatas;
        public IEnumerable<AppData> AppDatas
        {
            get { return this.appDatas; }
            set { SetProperty(ref this.appDatas, value); } 
        }

        // データ読み込み中などにスピナーを表示するために使う値
        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }

        // データを読み込む時に呼ばれるコマンド
        public DelegateCommand ReadAppDataCommand { get; }

		// 詳細ページへと遷移したい時に呼ばれるコマンド (引数はアプリID)
		public DelegateCommand<string> NavigateToDetailCommand { get; }

        // 新規登録ページへと遷移したい時に呼ばれるコマンド
        public DelegateCommand NavigateToRegisterPageCommand { get; }


        // IAppDataService からデータを取ってきている
        private async Task ReadAppDataAsync()
        {
            this.IsBusy = true;
            this.AppDatas = await this.appDataService.GetAllAppDatasAsync();
            this.IsBusy = false;
        }


        // 他のページへと画面遷移しようとしている時
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        // 画面遷移してきたときに呼ばれる
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}

