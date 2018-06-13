using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Recursos.Global;

namespace XF.Recursos.PassParameter
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MCHomeView : ContentPage
	{
        public MCHomeView()
        {
            InitializeComponent();
            AtivarCentroMensagens();
        }

        private void AtivarCentroMensagens()
        {
            MessagingCenter.Subscribe<MCHomeView>(this, "MensagemInfo",
                (sender) =>
                {
                    lblBoasVindas.Text = "Continue explorando...";
                });
        }

        private async void btnInfo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MCInfoView(), true);
        }

        private async void btnDetalhe_Clicked(object sender, EventArgs e)
        {
            var detalhe = new MCDetalheView();
            await Navigation.PushAsync(detalhe);

            var contato = new Contato
            {
                Nome = "Rafael dos Santos",
                Idade = 32,
                Profissao = "Lutador",
                Pais = "Brasil"
            };

            MessagingCenter.Send<MCHomeView, Contato>(this,
                MessagingViewModel.Navegacao.Alterar.ToString(), contato);
        }
    }
}