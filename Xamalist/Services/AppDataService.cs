using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamalist.Services;

namespace Xamalist
{
    public class AppDataService : IAppDataService
    {
        public AppDataService(IMobileServiceClient client)
        {
            // サーバから AppData のデータを取るための IMobileServiceTable を作成
            this.appDataTable = client.GetTable<AppData>();
        }

        private IMobileServiceTable<AppData> appDataTable;

        // Azure Mobile Apps から、データを全件(max50)取ってくる
        public async Task<IEnumerable<AppData>> GetAllAppDatasAsync()
        {
            // TODO: IsVisible が false のものは除外する
            // TODO: Paging 対応 (50件しか取ってこないので)
            return await this.appDataTable.CreateQuery().ToEnumerableAsync();
        }

        // Azure Mobile Apps から、データを 1件だけ取ってくる
        public Task<AppData> GetAppDataAsync(string id)
        {
            return this.appDataTable.LookupAsync(id);
        }

        // AppData を 1件 Azureに登録するメソッド。登録ページで使う
        public Task InsertAppDataAsync(AppData appData)
        {
            return this.appDataTable.InsertAsync(instance: appData);
        }
    }
}
