using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloWorldApp.Services
{
    public interface IEntradaDataStore<T>
    {
        Task<bool> AddEntradaAsync(T item);
        Task<bool> UpdateEntradaAsync(T item);
        Task<bool> DeleteEntradaAsync(T item);
        Task<T> GetEntradaAsync(string id);
        Task<IEnumerable<T>> GetEntradasAsync(bool forceRefresh = false);
    }
}
