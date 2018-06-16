using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.CustomControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomView : ContentPage
	{
		public CustomView ()
		{
			InitializeComponent ();
		}

        private void FiapButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Custom", "Botão personalizado", "OK");
        }
    }
}