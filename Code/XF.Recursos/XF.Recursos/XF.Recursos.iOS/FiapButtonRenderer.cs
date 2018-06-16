using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Recursos.CustomControl;
using XF.Recursos.iOS;

[assembly: ExportRenderer(typeof(FiapButton), typeof(FiapButtonRenderer))]
namespace XF.Recursos.iOS
{
    class FiapButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Gray;
            }
        }
    }
}