using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF.Recursos.CustomControl;
using XF.Recursos.Droid;

[assembly: ExportRenderer(typeof(FiapButton), typeof(FiapButtonRenderer))]
namespace XF.Recursos.Droid
{
    class FiapButtonRenderer : ButtonRenderer
    {
        public FiapButtonRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Gray);

                FiapButton fiapButton = (FiapButton)Element;

                string texto = (string)fiapButton.Texto;

                Control.Text = texto;

                //Control.SetText(texto, Android.Widget.TextView.BufferType.Spannable);
            }

            
        }
    }
}
