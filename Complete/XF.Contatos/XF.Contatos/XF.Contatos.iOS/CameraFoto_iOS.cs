using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Media;
using System.Threading.Tasks;
using XF.Contatos.App_Code;
using XF.Contatos.iOS;

[assembly: Dependency(typeof(CameraFoto_iOS))]
namespace XF.Contatos.iOS
{
    public class CameraFoto_iOS : ICamera
    {
        public void CapturarFoto()
        {
            var captura = new MediaPicker();
            if (captura.IsCameraAvailable)
            {
                MediaPickerController controller = captura.GetTakePhotoUI(new StoreCameraMediaOptions
                {
                    Name = string.Format("foto_{0}.jpg", DateTime.Now.ToString()),
                    Directory = "Aplicativo"
                });
                TaskScheduler.FromCurrentSynchronizationContext();
            }
        }

        public void SelecionarFoto()
        {
            var captura = new MediaPicker();
            captura.PickPhotoAsync().ContinueWith(e =>
            {
                MessagingCenter.Send<ICamera, string>(this, "cameraFoto", e.Result.Path);
            }, 
            TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}