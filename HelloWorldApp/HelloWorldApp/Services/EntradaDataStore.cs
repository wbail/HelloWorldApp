using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HelloWorldApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(HelloWorldApp.Services.EntradaDataStore))]
namespace HelloWorldApp.Services
{
    public class EntradaDataStore : IEntradaDataStore<Entrada>
    {
        List<Entrada> items;

        public EntradaDataStore()
        {
            items = new List<Entrada>();
            var mockEntradas = new List<Entrada>
            {
                new Entrada { Id = Guid.NewGuid().ToString(), HoraAcorda = DateTime.Now, HoraDorme = DateTime.Now },
                new Entrada { Id = Guid.NewGuid().ToString(), HoraAcorda = DateTime.Now.AddSeconds(5), HoraDorme = DateTime.Now.AddHours(2) },
            };

            foreach (var item in mockEntradas)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddEntradaAsync(Entrada item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateEntradaAsync(Entrada item)
        {
            var _item = items.Where((Entrada arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteEntradaAsync(Entrada item)
        {
            var _item = items.Where((Entrada arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Entrada> GetEntradaAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Entrada>> GetEntradasAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}