using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.API
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhoneView : ContentPage
	{
		public PhoneView ()
		{
			InitializeComponent ();
		}

        private async void OnCall(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                if (await this.DisplayAlert("Ligando...", "Ligar para " + txtTelefone.Text + "?", "Sim", "Não"))
                {
                    var phone = DependencyService.Get<ILigar>();
                    if (phone != null) phone.Discar(txtTelefone.Text);
                }
            }
        }
    }
}