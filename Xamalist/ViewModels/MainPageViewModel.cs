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
        public MainPageViewModel(IAppDataService appDataService)
        {
            this.appDataService = appDataService;
            this.ReadAppDataCommand = new DelegateCommand(async () => await this.ReadAppDataAsync());
        }

        private IAppDataService appDataService;
        private IEnumerable<AppData> appDatas;
        public IEnumerable<AppData> AppDatas
        {
            get { return this.appDatas; }
            set { SetProperty(ref this.appDatas, value); } 
        }
        // データを読み込む時に呼ばれるコマンド
        public DelegateCommand ReadAppDataCommand { get; }


        // IAppDataService からデータを取ってきている
        private async Task ReadAppDataAsync()
        {
            this.AppDatas = await this.appDataService.GetAllAppDatas();
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

