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
	public partial class MCDetalheView : ContentPage
	{
        public MCDetalheView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MCHomeView, Contato>(this,
                MessagingViewModel.Navegacao.Alterar.ToString(),
               (navegarParametro, param) =>
               {
                   BindingContext = param;
                   MessagingCenter.Unsubscribe<MCHomeView, Contato>(
                       this, MessagingViewModel.Navegacao.Alterar.ToString());
               });
        }

        private void btnVoltar_Clicked(object sender, EventArgs args)
        {
            Navigation.PopAsync();
        }
    }
}