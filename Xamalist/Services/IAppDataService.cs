using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Xamalist
{
    public interface IAppDataService
    {
        Task<IEnumerable<AppData>> GetAllAppDatas();
    }
}
