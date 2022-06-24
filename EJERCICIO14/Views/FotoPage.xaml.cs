using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO14.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotoPage : ContentPage
    {
        public FotoPage()
        {
            InitializeComponent();
        }

        Plugin.Media.Abstractions.MediaFile FileFoto = null;
        private Byte[] ConvertImageToByteArray()
        {
            if (FileFoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = FileFoto.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }
        private async void Foto_Clicked(object sender, EventArgs e)
        {

            FileFoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "test.jpg",
                SaveToAlbum = true

            });
            await DisplayAlert("path directorio", FileFoto.Path, "OK");

            if (FileFoto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return FileFoto.GetStream();
                });
            }

        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {

                if (FileFoto == null)
                {
                    await DisplayAlert("Error", "NO ha tomado una fotografia", "OK");
                }

                var persona = new Models.Persona()
                {
                    foto = ConvertImageToByteArray(),
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text
                };

                var resultado = await App.BaseDatos.GuardarPersona(persona);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingreso Exitoso", "OK");
                    ClearScreen();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar la persona", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Agregado", ex.Message.ToString(), "OK");
            }

        }
            private void ClearScreen()
            {
                this.txtNombre.Text = String.Empty;
                this.txtDescripcion.Text = String.Empty;
            }

        }
    
}