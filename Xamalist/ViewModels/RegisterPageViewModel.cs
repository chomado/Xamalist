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
                executeMethod:    async () => await this.RegisterAppDataAsync(),
                canExecuteMethod: () => !this.IsBusy /* コマンドが実行可能のときに true を返す */
            )
            .ObservesProperty(propertyExpression: () => this.IsBusy); // IsBusyプロパティを監視し、IsBusyに変化があったら、CanExecuteChangedイベントを発行する
        }

        private IAppDataService appDataService;

        // 登録ボタン
        public DelegateCommand RegisterCommand { get; }


        // データ読み込み中などにスピナーを表示するために使う値
        private bool isBusy;
        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }


        // --- 新規登録する時にデータを入れる入れ物 ----
        private AppData registeringAppData = new AppData();
        public AppData RegisteringAppData
        {
            get { return this.registeringAppData; }
            set { SetProperty(ref this.registeringAppData, value); }
        }

        private async Task RegisterAppDataAsync()
        {
            /* 登録ボタンが押される
             * → ぐるぐる ＆ ボタン非アクティブ
             * → 「登録されました！」トースト
             * → 前の画面(MainPage)に自動遷移
             * → 勝手にリストが「更新」される
             */
            this.IsBusy = true;
            await this.appDataService.InsertAppDataAsync(this.RegisteringAppData);
            this.IsBusy = false;
        }
	}
}
