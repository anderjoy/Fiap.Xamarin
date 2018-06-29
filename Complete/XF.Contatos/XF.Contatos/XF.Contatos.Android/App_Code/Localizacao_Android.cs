using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XF.Contatos.Droid.App_Code;
using XF.Contatos.App_Code;
using Xamarin.Geolocation;
using System.Threading.Tasks;

[assembly: Dependency(typeof(Localizacao_Android))]
namespace XF.Contatos.Droid.App_Code
{
    public class Localizacao_Android : ILocalizacao
    {
        public void GetCoordenada()
        {
            var context = Forms.Context as Activity;
            var locator = new Geolocator(context) { DesiredAccuracy = 50 };
            locator.GetPositionAsync(timeout: 10000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
                System.Diagnostics.Debug.WriteLine(t.Result.Latitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordenada", coordenada);
        }
    }
}