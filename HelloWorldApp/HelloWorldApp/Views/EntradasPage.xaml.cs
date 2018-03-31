using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HelloWorldApp.Models;
using HelloWorldApp.Views;
using HelloWorldApp.ViewModels;

namespace HelloWorldApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntradasPage : ContentPage
	{
        EntradasViewModel viewModel;

        public EntradasPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EntradasViewModel();
        }

        async void OnEntradaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Entrada;
            if (item == null)
                return;

            await Navigation.PushAsync(new EntradaDetailPage(new EntradaDetailViewModel(item)));

            // Manually deselect item.
            EntradasListView.SelectedItem = null;
            
        }

        async void AddEntrada_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEntradaPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Entradas.Count == 0)
                viewModel.LoadEntradasCommand.Execute(null);
        }
    }
}