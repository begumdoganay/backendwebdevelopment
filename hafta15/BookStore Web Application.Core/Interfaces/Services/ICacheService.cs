using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Web_Application.Core.Interfaces.Services
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task RemoveAsync(string key);
    }
}
