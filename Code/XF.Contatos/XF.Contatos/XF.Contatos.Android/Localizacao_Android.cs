using Android.App;
using Android.Content;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Geolocation;
using XF.Contatos.API;
using XF.Contatos.Droid;
using XF.Contatos.Model;

[assembly: Dependency(typeof(Localizacao_Android))]
namespace XF.Contatos.Droid
{
    public class Localizacao_Android : ILocalizacao
    {
        public void GetCoordenada()
        {
            var context = MainApplication.CurrentContext as Activity;
            var locator = new Geolocator(context) { DesiredAccuracy = 50 };

            locator.GetPositionAsync(timeout: 10000).ContinueWith(t =>
            {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void GoToCoordenada(Coordenada coordenada)
        {
            var context = MainApplication.CurrentContext as Activity;

            var geoUri = Android.Net.Uri.Parse($"geo:{coordenada.Latitude},{coordenada.Longitude}");
            var mapIntent = new Intent(Intent.ActionView, geoUri);

            if (IsIntentAvailable(context, mapIntent))
            {
                context.StartActivity(mapIntent);
            }
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any()) return true;

            return false;
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            // Enviar coordenada via MessagingCenter
            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordenada", coordenada);
        }
    }
}
