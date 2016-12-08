using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Media;
using Xamalist.ViewModels;
using Xamarin.Forms;

namespace Xamalist.Views
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage()
		{
			InitializeComponent();
		}

        public async void OnImageButtonClicked(Object sender, EventArgs args)
        { 
            await CrossMedia.Current.Initialize();

            // 画像フォルダの選択画面が出てくる
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
            {
                return;
            }

            Debug.WriteLine(file.Path);

            // プレビューを出す
            this.ImagePreview.Source = ImageSource.FromStream(file.GetStream);

            var viewModel = (RegisterPageViewModel)this.BindingContext;
            viewModel.IconImage = file; // 選んだファイルを ViewModel に設定する
        }
	}
}
