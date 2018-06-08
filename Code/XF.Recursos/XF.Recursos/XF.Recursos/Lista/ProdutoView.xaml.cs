using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Lista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoView : ContentPage
    {
        ViewModelProdutos _vmProdutos;

        public ProdutoView()
        {
            if (_vmProdutos == null)
                _vmProdutos = new ViewModelProdutos();

            BindingContext = _vmProdutos;

            InitializeComponent();
            LoadProdutos();
        }

        private async void LoadProdutos()
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStringAsync("https://apiaplicativofiap.azurewebsites.net/content/xml/produtos.xml");

            XElement xmlProduto = XElement.Parse(stream);
            foreach (var item in xmlProduto.Elements("produto"))
            {
                Produto produto = new Produto()
                {
                    Id = int.Parse(item.Attribute("id").Value),
                    Descricao = item.Element("descricao").Value,
                    Categoria = item.Element("categoria").Value,
                    Quantidade = int.Parse(item.Element("quantidade").Value),
                    Preco = decimal.Parse(item.Element("precounitario").Value)
                };
                _vmProdutos.ProdutosFiltrado.Add(produto);
                _vmProdutos.AplicarFiltro();
            }
        }

        private void lstProduto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelecionado = e.Item as Produto;
            DisplayAlert("Produto selecionado",
                $"Id: {itemSelecionado.Id} - {itemSelecionado.Descricao}", "OK");
        }
    }

    public class ViewModelProdutos : INotifyPropertyChanged
    {
        private string pesquisaPorDescricao;
        public string PesquisaPorDescricao
        {
            get { return pesquisaPorDescricao; }
            set
            {
                if (value == pesquisaPorDescricao) return;

                pesquisaPorDescricao = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorDescricao)));
                AplicarFiltro();
            }
        }

        public List<Produto> ProdutosFiltrado { get; set; } = new List<Produto>();
        public ObservableCollection<Produto> Produtos { get; set; } = new ObservableCollection<Produto>();

        public ViewModelProdutos() { }

        public void AplicarFiltro()
        {
            if (PesquisaPorDescricao == null) PesquisaPorDescricao = "";

            var resultado = ProdutosFiltrado.Where(n => n.Descricao.ToLowerInvariant()
                                .Contains(pesquisaPorDescricao.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = Produtos.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                Produtos.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > Produtos.Count || !Produtos[index].Equals(item))
                    Produtos.Insert(index, item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}