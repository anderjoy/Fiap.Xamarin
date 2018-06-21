using Android.App;
using Android.Content;
using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Media;
using XF.Contatos.API;
using XF.Contatos.Droid;

[assembly: Dependency(typeof(TakePhoto_Android))]
[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]
namespace XF.Contatos.Droid
{
    public class TakePhoto_Android : ITakePhoto
    {
        public void GetPhotoFromCamera()
        {
            var context = MainApplication.CurrentContext as Activity;
            if (context == null) return;

            var picker = new MediaPicker(context);

            if (picker.IsCameraAvailable)
            {
                try
                {
                    var intent = picker.GetTakePhotoUI(new StoreCameraMediaOptions { Name = "photo.jpg", Directory = "ContatosPickerPhoto", DefaultCamera = CameraDevice.Front });

                    if (IsIntentAvailable(context, intent))
                    {
                        context.StartActivityForResult(intent, PhotoConstant.REQUEST_CAMERA);
                    }
                }
                catch (OperationCanceledException)
                {
                }
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
    }
}
