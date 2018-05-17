using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.ControlesBasicos.App_Code;

namespace XF.ControlesBasicos
{
	public partial class MainPage : ContentPage
	{
        Email emailmodel;

        public MainPage()
        {
            InitializeComponent();

            if (emailmodel == null)
                emailmodel = new Email();
        }

        private void Config_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfigPage() { BindingContext = emailmodel });
        }

        private void Enviar_Clicked(object sender, EventArgs e)
        {
            if ((emailmodel.Ativo) && (!string.IsNullOrEmpty(emailmodel.ContaEmail)))
                DisplayAlert("Mensagem",
                    $"E-mail enviado para {emailmodel.ContaEmail}", "Ok");
            else
                DisplayAlert("Mensagem", "Envio não autorizado", "Ok");

        }
    }
}
