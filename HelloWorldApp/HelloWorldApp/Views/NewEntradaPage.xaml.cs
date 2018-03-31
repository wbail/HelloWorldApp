using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HelloWorldApp.Models;

namespace HelloWorldApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntradaPage : ContentPage
    {
        public Entrada Entrada { get; set; }

        public NewEntradaPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Entrada);
            await Navigation.PopModalAsync();
        }
    }
}