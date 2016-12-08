using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Services;

namespace Xamalist.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        public RegisterPageViewModel(IAppDataService appDataService, IPageDialogService pageDialogService)
        {
            this.appDataService = appDataService; // データの登録に必要
            this.pageDialogService = pageDialogService; // アラートを出すために必要な人

            // 登録ボタンが押された時のコマンドを定義
            this.RegisterCommand = new DelegateCommand(
                executeMethod:    async () => await this.RegisterAppDataAsync(),
                canExecuteMethod: () => !this.IsBusy /* コマンドが実行可能のときに true を返す */
            )
            .ObservesProperty(propertyExpression: () => this.IsBusy); // IsBusyプロパティを監視し、IsBusyに変化があったら、CanExecuteChangedイベントを発行する
        }

        private IAppDataService appDataService;
        private IPageDialogService pageDialogService;

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

            await this.pageDialogService.DisplayAlertAsync(
                title: "登録完了",
                message: $"{this.registeringAppData.Name} の登録が完了しました",
                cancelButton: "OK"
            );
        }
	}
}
