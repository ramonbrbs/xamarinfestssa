using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();

            LstNoticias.RefreshCommand = new Command(CarregarNoticias);
            CarregarNoticias();
        }


        public async void CarregarNoticias()
        {
            try
            {
                LstNoticias.IsRefreshing = true;
                using (var cliente = new System.Net.Http.HttpClient())
                {
                    var Json = await cliente.GetStringAsync("http://xamarinssa.azurewebsites.net/tables/noticias/?ZUMO-API-VERSION=2.0.0");
                    var noticias = JsonConvert.DeserializeObject<List<Noticia>>(Json);
                    LstNoticias.ItemsSource = noticias;
                    //return noticias;
                }
                LstNoticias.IsRefreshing = false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        private void LstNoticias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var noticia = (Noticia)e.SelectedItem;
            Navigation.PushAsync(new Detalhes(noticia));
        }
    }
}
