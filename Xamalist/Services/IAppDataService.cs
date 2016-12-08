using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Xamalist.Services
{
    public interface IAppDataService
    {
		// Azure から、データを全部(現在max50)取ってくるためのメソッド。一覧ページで使う
        Task<IEnumerable<AppData>> GetAllAppDatasAsync();

		// Azure から、データを 1件だけ取ってくるためのメソッド。詳細ページで使う
		Task<AppData> GetAppDataAsync(string id);

        // AppData を 1件 Azureに登録するメソッド。登録ページで使う
        Task InsertAppDataAsync(AppData appData);
    }
}
