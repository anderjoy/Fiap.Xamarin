using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.PassParameter
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MCInfoView : ContentPage
	{
		public MCInfoView ()
		{
			InitializeComponent ();
		}

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var mcHome = new MCHomeView();
            MessagingCenter.Send<MCHomeView>(mcHome, "MensagemInfo");
        }
    }
}