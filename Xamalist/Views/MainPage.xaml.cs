using Xamalist.ViewModels;
using Xamarin.Forms;

namespace Xamalist.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		// リストのアイテムがタップされた時に呼ばれる
		public void OnItemTapped(object sender, SelectedItemChangedEventArgs e)
		{
			// 未選択状態の時は何もしない
			if (e.SelectedItem == null)
			{
				return;
			}
				
			var listView = (ListView)sender;

			// 渡ってきた、アプリの情報(AppDataのアイテム)
			var appDataItem = (AppData)e.SelectedItem;

			// タップしても色が変わらないようにする処理
			listView.SelectedItem = null;

			var mainPageViewModel = (MainPageViewModel)this.BindingContext;

			// 詳細ページへの遷移のコマンド実行
			mainPageViewModel.NavigateToDetailCommand.Execute(appDataItem.Id);
		}
    }
}

