using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XF.Recursos.CustomControl;
using XF.Recursos.iOS;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(FiapBoxView), typeof(FiapBoxViewRenderer))]
namespace XF.Recursos.iOS
{
    public class FiapBoxViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            FiapBoxView boxView = (FiapBoxView)Element;
            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetFillColor(boxView.Color.ToCGColor());
                context.SetStrokeColor(boxView.CorDaBorda.ToCGColor());
                context.SetLineWidth((float)boxView.EspessuraDaBorda);

                var ret = Bounds.Inset((int)boxView.EspessuraDaBorda,
                    (int)boxView.EspessuraDaBorda);

                var path = CGPath.FromRect(ret);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == FiapBoxView.EspessuraDaBordaProperty.PropertyName)
            {
                SetNeedsDisplay();
            }
        }

    }
}
