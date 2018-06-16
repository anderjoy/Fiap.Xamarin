using Foundation;
using UIKit;
using Xamarin.Forms;
using XF.Recursos.API;
using XF.Recursos.iOS;

[assembly: Dependency(typeof(Ligar_iOS))]
namespace XF.Recursos.iOS
{
    public class Ligar_iOS : ILigar
    {
        public bool Discar(string telefone)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + telefone));
        }
    }
}