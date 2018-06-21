using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using XF.Contatos.API;
using Xamarin.Forms;
using Xamarin.Media;
using System.IO;

namespace XF.Contatos.Droid
{
    [Activity(Label = "XF.Contatos", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }


        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                if (requestCode == PhotoConstant.REQUEST_CAMERA)
                {
                    MediaFile file = await data.GetMediaFileExtraAsync(this);
                    var photo = file.GetStream();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        await photo.CopyToAsync(ms);

                        ITakePhoto take = DependencyService.Get<ITakePhoto>();

                        MessagingCenter.Send<ITakePhoto, byte[]>(take, "photo", ms.ToArray());
                    }
                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}

