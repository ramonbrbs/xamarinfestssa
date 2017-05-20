using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalhes : ContentPage
    {
        private Noticia _noticia;
        public Detalhes(Noticia noticia)
        {
            InitializeComponent();
            _noticia = noticia;
            BindingContext = noticia;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(_noticia.Url));
        }
    }
}
