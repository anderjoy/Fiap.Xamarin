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

namespace XF.Recursos.Lista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaEtiquetaView : ContentPage
	{
        ObservableCollection<GrupoDeItensCollection> lista;
        public ListaEtiquetaView()
        {
            InitializeComponent();

            lista = PrepararLista();
            lstEtiqueta.ItemsSource = lista;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemDaLista = (ItemNaLista)e.Item;
            DisplayAlert(itemDaLista.Nome,
                "Item selecionado: " + itemDaLista.Nome, "OK", "Cancel");
        }

        ObservableCollection<GrupoDeItensCollection> PrepararLista()
        {
            var agruparItens = new ObservableCollection<GrupoDeItensCollection>();

            foreach (var item in GrupoDeItensCollection.GetListaOrdenada())
            {
                var grupo = agruparItens.FirstOrDefault(g => g.Titulo == item.Etiqueta);
                if (grupo == null)
                {
                    grupo = new GrupoDeItensCollection(item.Etiqueta);
                    grupo.Add(item);
                    agruparItens.Add(grupo);
                }
                else grupo.Add(item);
            }
            return agruparItens;
        }

        private void lstEtiqueta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            foreach (ItemNaLista item in GrupoDeItensCollection.GetListaOrdenada())
            {
                if (item.Nome == ((ItemNaLista)e.SelectedItem).Nome)
                    item.CorDeFundo = "Silver";
                else item.CorDeFundo = "Transparent";
            }
        }

        private async void lstEtiqueta_Refreshing(object sender, EventArgs e)
        {
            var lista = ((ListView)sender);
            try
            {
                await Task.Delay(4000);
                // await DisplayAlert("Info", "Lista atualizada", "OK");
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

    // Representa um conjunto de dados agrupados na lista.
    public class GrupoDeItensCollection : ObservableCollection<ItemNaLista>
    {
        public string Titulo { get; private set; }

        public GrupoDeItensCollection(string paramTitulo)
        {
            Titulo = paramTitulo;
        }

        public static List<ItemNaLista> GetListaOrdenada()
        {
            var itensOrdenados = Itens;
            itensOrdenados.Sort();

            return itensOrdenados;
        }

        static readonly List<ItemNaLista> Itens = new List<ItemNaLista>() {
            new ItemNaLista ("Anderson Silva"),
            new ItemNaLista ("Conor McGregor"),
            new ItemNaLista ("Vanderlei Silva"),
            new ItemNaLista ("José Aldo"),
            new ItemNaLista ("Amanda Nunes"),
            new ItemNaLista ("Daniel Cormier"),
            new ItemNaLista ("John Jones"),
            new ItemNaLista ("Tyron Woodley"),
            new ItemNaLista ("Demian Maia"),
            new ItemNaLista ("Cris Cyborg"),
            new ItemNaLista ("Rafael dos Santos"),
        };
    }

    // Representa um item na lista
    public class ItemNaLista : IComparable<ItemNaLista>, INotifyPropertyChanged
    {
        public string Nome { get; private set; }
        public string corDeFundo;
        public string CorDeFundo
        {
            get
            {
                if (string.IsNullOrEmpty(corDeFundo)) return "Transparent";

                return corDeFundo;
            }
            set
            {
                corDeFundo = value;
                EventPropertyChanged();
            }
        }

        public ItemNaLista(string paramNome)
        {
            Nome = paramNome;
        }

        int IComparable<ItemNaLista>.CompareTo(ItemNaLista value)
        {
            return Nome.CompareTo(value.Nome);
        }

        public string Etiqueta
        {
            get
            {
                return Nome[0].ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}