using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HelloWorldApp.Models;
using HelloWorldApp.ViewModels;

namespace HelloWorldApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntradaDetailPage : ContentPage
	{
        EntradaDetailViewModel viewModel;

        public EntradaDetailPage(EntradaDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public EntradaDetailPage()
        {
            InitializeComponent();

            var item = new Entrada
            {
                HoraAcorda = DateTime.Now,
                HoraDorme = DateTime.Now
            };

            viewModel = new EntradaDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}