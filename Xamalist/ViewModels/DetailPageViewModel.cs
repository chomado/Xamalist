using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamalist.Services;

namespace Xamalist.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        public DetailPageViewModel(IAppDataService appDataService)
        {
            this.appDataService = appDataService;
        }


        // アプリのデータ(AppData)
        private AppData appDataItem;
        public AppData AppDataItem
        {
            get { return this.appDataItem; }
            set { SetProperty(ref this.appDataItem, value); }
        }

        private IAppDataService appDataService;

        // 他のページへと画面遷移しようとしている時
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        // 画面遷移してきたときに呼ばれる
        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var id = parameters["id"].ToString();

            this.AppDataItem = await appDataService.GetAppDataAsync(id);
        }
    }
}
