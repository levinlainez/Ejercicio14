using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EJERCICIO14.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void datos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.FotoPage());
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listaperson = await App.BaseDatos.ObtenerListaPersona();
            lsPersona.ItemsSource = listaperson;
        }
    }
}
