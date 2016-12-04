using System;
using System.Threading.Tasks;
namespace Xamalist
{
    public interface IAppDataService
    {
        Task<IEquatable<AppData>> GetAllAppDatas();
    }
}
