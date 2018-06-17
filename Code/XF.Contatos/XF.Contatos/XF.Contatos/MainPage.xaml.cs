using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.API;

namespace XF.Contatos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        ViewModelContatos _vmContatos;

        public MainPage()
		{
            if (_vmContatos == null)
            {
                _vmContatos = new ViewModelContatos();
            }			

            BindingContext = _vmContatos;

            InitializeComponent();
            CarregarContatos();
        }

        private void CarregarContatos()
        {
            var contatosService = DependencyService.Get<IContatos>();
            if (contatosService != null)
            {
                contatosService.GetContatos();

                MessagingCenter.Subscribe<IContatos, IList<Contato>>(this, "contatos",
                    (objeto, contatos) =>
                    {
                        _vmContatos.Contatos.Clear();
                        foreach (var contato in contatos)
                        {
                            _vmContatos.Contatos.Add(new Contato()
                            {
                                Nome = contato.Nome,
                                Telefone = contato.Telefone
                            });
                        }
                    });
            }
        }

        private void lstContatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Contato;
            DisplayAlert("Contato selecionado",
                $"Nome: {itemSelecionado.Nome} - {itemSelecionado.Telefone}", "OK");
        }

        private void lstContatos_Refreshing(object sender, EventArgs e)
        {
            var lista = ((ListView)sender);

            try
            {
                CarregarContatos();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                lista.EndRefresh();
            }

        }
    }

    public class ViewModelContatos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        public ViewModelContatos()
        {

        }

        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
