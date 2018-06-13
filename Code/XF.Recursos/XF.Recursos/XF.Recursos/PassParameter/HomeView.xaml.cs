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
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();
		}

        public HomeView(string paramData)
        {
            InitializeComponent();

            lblData.Text = paramData;
        }

        private async void btnDetalhe_Clicked(object sender, EventArgs e)
        {
            var contato = new Contato
            {
                Nome = "Rafael dos Santos",
                Idade = 33,
                Profissao = "Lutador",
                Pais = "Brasil"
            };

            var detalhePage = new DetalheView();
            detalhePage.BindingContext = contato;
            await Navigation.PushModalAsync(detalhePage);
        }
    }
}