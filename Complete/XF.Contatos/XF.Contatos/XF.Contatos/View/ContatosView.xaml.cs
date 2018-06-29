using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.Model;
using XF.Contatos.ViewModel;

namespace XF.Contatos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatosView : ContentPage
    {
        public ContatoViewModel contatosVM = new ContatoViewModel();
        public ContatosView()
        {
            BindingContext = contatosVM;
            InitializeComponent();

            GetContatos(contatosVM);
        }

        private void GetContatos(ContatoViewModel vm)
        {
            IContato lista = DependencyService.Get<IContato>();
            lista.GetMobileContacts(vm);
        }
    }
}