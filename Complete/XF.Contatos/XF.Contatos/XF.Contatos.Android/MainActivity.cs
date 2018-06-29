using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XF.Contatos.App_Code;
using Xamarin.Media;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android.Content;

[assembly: Dependency(typeof(XF.Contatos.Droid.MainActivity))]
namespace XF.Contatos.Droid
{
    [Activity(Label = "XF.Contatos", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            DependencyService.Register<IVersionHelper, VersionHelper>();
            LoadApplication(new App());
        }

        public void CapturarFoto()
        {
            // Android.App.Application.Context
            var context = MainApplication.CurrentContext as Activity;
            var captura = new MediaPicker(context);

            if (captura.IsCameraAvailable)
            {
                var intent = captura.GetTakePhotoUI(new StoreCameraMediaOptions
                {
                    Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                    Directory = "Aplicativo"
                });
                context.StartActivityForResult(intent, 1);
            }
        }

        public void SelecionarFoto()
        {
            var context = MainApplication.CurrentContext as Activity;
            var captura = new MediaPicker(context);

            var intent = captura.GetPickPhotoUI();
            context.StartActivityForResult(intent, 1);
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled) return;

            await data.GetMediaFileExtraAsync(MainApplication.CurrentContext).ContinueWith(e =>
            {
                MessagingCenter.Send<ICamera, string>(this, "cameraFoto", e.Result.Path);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

