using System;

using HelloWorldApp.Models;

namespace HelloWorldApp.ViewModels
{
    public class EntradaDetailViewModel : BaseViewModel
    {
        public Entrada Entrada { get; set; }
        public EntradaDetailViewModel(Entrada entrada = null)
        {
            Entrada = entrada;
        }
    }
}
