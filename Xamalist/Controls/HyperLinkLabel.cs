using System;
using Xamarin.Forms;

namespace Xamalist.Controls
{
	// タップしたらテキストの中身を開く、という機能を持つラベル
	public class HyperLinkLabel : Label
	{
		public HyperLinkLabel()
		{
			// 文字色を変える
			this.TextColor = Color.Gray;

			// タップした時に URLを開く、という処理を書いている
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (sender, e) => {
				Device.OpenUri(new Uri(((HyperLinkLabel)sender).Url));
			};
			this.GestureRecognizers.Add(tapGestureRecognizer);
		}

		// "Url" という名前の BindableProperty を定義
		public static readonly BindableProperty UrlProperty = BindableProperty.Create(
			propertyName: "URL",
			returnType: typeof(string),
			declaringType: typeof(HyperLinkLabel),
			defaultValue: null
		);

		// BindableProperty の CLRプロパティの wrapper
		public string Url { 
			get { return (string)GetValue(UrlProperty); }
			set { SetValue(UrlProperty, value); }
		}

	}
}
