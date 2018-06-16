using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.CustomControl
{
    public class FiapButton : Button
    {
        public static readonly BindableProperty TextoProperty =
            BindableProperty.Create<FiapButton, string>(p => p.Texto, default(string));

        public string Texto
        {
            get { return (string)GetValue(TextoProperty); }
            set { SetValue(TextoProperty, value); }

        }
    }

    public class ColorFromRGBExtension : IMarkupExtension
    {
        public int Vermelho { get; set; }
        public int Verde { get; set; }
        public int Azul { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromRgb(Vermelho, Verde, Azul);
        }
    }

    public class FiapBoxView : BoxView
    {
        public static readonly BindableProperty CorDaBordaProperty =
            BindableProperty.Create<FiapBoxView, Color>(p => p.CorDaBorda, default(Color));

        public Color CorDaBorda
        {
            get { return (Color)GetValue(CorDaBordaProperty); }
            set { SetValue(CorDaBordaProperty, value); }
        }

        public static readonly BindableProperty EspessuraDaBordaProperty =
            BindableProperty.Create<FiapBoxView, double>(p => p.EspessuraDaBorda, default(double));

        public double EspessuraDaBorda
        {
            get { return (double)GetValue(EspessuraDaBordaProperty); }
            set { SetValue(EspessuraDaBordaProperty, value); }
        }
    }
}
