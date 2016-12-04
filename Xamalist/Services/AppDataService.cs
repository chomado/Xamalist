using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

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

        // Azure Mobile Apps から、データを取ってくる
        public async Task<IEnumerable<AppData>> GetAllAppDatas()
        {
            return await this.appDataTable.CreateQuery().ToEnumerableAsync();
        }
    }
}
