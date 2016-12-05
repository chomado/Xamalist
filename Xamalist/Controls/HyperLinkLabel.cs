using System;
using Xamarin.Forms;

namespace Xamalist.Controls
{
	// タップしたらテキストの中身を開く、という機能を持つラベル
	public class HyperLinkLabel : Label
	{
		public HyperLinkLabel()
		{
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (sender, e) => {
				Device.OpenUri(new Uri(((Label)sender).Text));
			};
			this.GestureRecognizers.Add(tapGestureRecognizer);
		}
	}
}
