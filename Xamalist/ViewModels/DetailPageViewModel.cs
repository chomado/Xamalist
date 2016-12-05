using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xamalist.ViewModels
{
	public class DetailPageViewModel : BindableBase, INavigationAware
	{
		public DetailPageViewModel()
		{
		}

        // 他のページへと画面遷移しようとしている時
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        // 画面遷移してきたときに呼ばれる
        public void OnNavigatedTo(NavigationParameters parameters)
        {
			var id = parameters["id"].ToString();
        }
	}
}
