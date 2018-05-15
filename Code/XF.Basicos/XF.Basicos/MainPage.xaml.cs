using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.ControlesBasicos
{
    public partial class MainPage : ContentPage
    {
        public ConfigEmail config;

        public MainPage()
        {
            if (config == null)
            {
                config = new ConfigEmail();
            }

            InitializeComponent();
        }

        private void Click_Enviar(object sender, EventArgs e)
        {
            if (config.CanSendEmail)
            {
                DisplayAlert("Mensagem", $"E-mail enviado para {config.Email}", "OK");
            }
            else
            {
                DisplayAlert("Atenção", "E-mail não autorizado", "OK");
            }
        }

        private void Click_Configuracao(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Configuracao() { BindingContext = config });
        }

    }
}
