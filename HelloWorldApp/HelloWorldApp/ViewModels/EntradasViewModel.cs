using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HelloWorldApp.Models;
using HelloWorldApp.Views;

namespace HelloWorldApp.ViewModels
{
    public class EntradasViewModel : BaseViewModel
    {
        public ObservableCollection<Entrada> Entradas { get; set; }
        public Command LoadEntradasCommand { get; set; }

        public EntradasViewModel()
        {
            Title = "Browse";
            Entradas = new ObservableCollection<Entrada>();
            LoadEntradasCommand = new Command(async () => await ExecuteLoadEntradasCommand());

            MessagingCenter.Subscribe<NewItemPage, Entrada>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Entrada;
                Entradas.Add(_item);
                await EntradaDataStore.AddEntradaAsync(_item);
            });
        }

        async Task ExecuteLoadEntradasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Entradas.Clear();
                var items = await EntradaDataStore.GetEntradasAsync(true);
                foreach (var item in items)
                {
                    Entradas.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}