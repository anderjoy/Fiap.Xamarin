using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StepperView : ContentPage
	{
		public StepperView ()
		{
			InitializeComponent ();
		}

        private void onIncremento_Changed(object sender, ValueChangedEventArgs e)
        {
            lblValor.Text = "Nota = " + stpIncremento.Value.ToString("F1");

            if (stpIncremento.Value >= 6d)
            {
                lblResultado.Text = "Aprovado";
                lblResultado.TextColor = Color.Blue;
            }
            else
            {
                lblResultado.Text = "Reprovado";
                lblResultado.TextColor = Color.Red;
            }
        }
    }
}