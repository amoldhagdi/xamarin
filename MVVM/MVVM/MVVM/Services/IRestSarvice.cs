using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public interface IRestSarvice
    {
        //Task<List<T>> Get<T>(string url, T Param);
        Task<List<T>> Get<T>(string url, string Param) where T : new();
        Task<List<T>> Post<T>(T data);
    }
}
