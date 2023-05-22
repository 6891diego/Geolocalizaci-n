using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Geolocalización
{
    public partial class MainPage : ContentPage
    {
        double lati;
        double longi;
        public MainPage()
        {
            InitializeComponent();
            Localizar();
        }
          
        private  async void Localizar()
        {
            var locator = CrossGeolocator.Current; //acceso a la app
            locator.DesiredAccuracy = 50; //Presicion (metros)
            if(locator.IsGeolocationAvailable) //servicio existente en el dispositivo
            {
                if (locator.IsGeolocationEnabled) // GPS activado en el dispositivo
                {
                    if(!locator.IsListening) // comprurba si el dispositivo escuchga al servicio

                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);//inicio de la escucha
                    }
                    locator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    lon.Text = loc.Longitude.ToString();
                    longi = double.Parse(long.Text);
                    lat.Text = loc.Latitude.ToString();
                    lati = double.Parse(lat.Text);
                };
            }

        }
    }

        private async void mostrarMapa(object sender, EventArgs args1)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posicion Actual"};
            await Map.OpenAsync(lati, longi, options);

        }
    }
}
