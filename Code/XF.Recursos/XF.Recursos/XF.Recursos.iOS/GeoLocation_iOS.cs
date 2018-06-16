using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Geolocation;
using XF.Recursos.GPS;
using XF.Recursos.iOS;

[assembly: Dependency(typeof(GeoLocation_iOS))]
namespace XF.Recursos.iOS
{
    public class GeoLocation_iOS : ILocalizacao
    {
        public void GetCoordenada()
        {
            var locator = new Geolocator { DesiredAccuracy = 50 };
            locator.GetPositionAsync(timeout: 10000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
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
