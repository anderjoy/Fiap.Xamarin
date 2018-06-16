using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Contatos.API;

namespace XF.Contatos
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<Contato> ListaContatos = new ObservableCollection<Contato>();

        public MainPage()
		{
			InitializeComponent();

            BindingContext = ListaContatos;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var contatosService = DependencyService.Get<IContatos>();
            if (contatosService != null)
            {
                var contatos = await contatosService.GetContatos();

                foreach (var contato in contatos)
                {
                    ListaContatos.Add(new Contato()
                    {
                        Nome = contato.Nome,
                        Telefone = contato.Telefone
                    });
                }
            }
        }
    }
}
