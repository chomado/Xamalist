using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamalist.ViewModels
{
    public class RegisterPageViewModel : BindableBase
	{
        public RegisterPageViewModel(IAppDataService appDataService)
		{
            this.appDataService = appDataService;


            // 登録ボタンが押された時のコマンドを定義
            this.RegisterCommand = new DelegateCommand(
                executeMethod: async () => await this.appDataService.InsertAppDataAsync(this.RegisteringAppData)
            );
		}

        private IAppDataService appDataService;

        // 登録ボタン
        public DelegateCommand RegisterCommand { get; }

        // --- 新規登録する時にデータを入れる入れ物 ----
        private AppData registeringAppData = new AppData();
        public AppData RegisteringAppData
        {
            get { return this.registeringAppData; }
            set { SetProperty(ref this.registeringAppData, value); }
        }


	}
}
