using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XF.Recursos.Lista.ViewModel
{
    public class ProdutoViewModel : INotifyPropertyChanged
    {
        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string Stream { get; set; }

        private string pesquisaPorNome;
        public string PesquisaPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                if (value == pesquisaPorNome) return;

                pesquisaPorNome = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PesquisaPorNome)));
                AplicarFiltro();
            }
        }

        public ProdutoViewModel()
        {
            Task.Run(async () =>
            {
                await GetProdutos(@"https://apiaplicativofiap.azurewebsites.net/content/xml/produtos.xml");

                CopiaListaProdutos = new List<Produto>();
                Carregar();
            });
        }

        public void Carregar()
        {
            ParserProdutos();
            AplicarFiltro();
        }

        private void ParserProdutos()
        {
            XElement xmlUsuarios = XElement.Parse(Stream);

            foreach (var item in xmlUsuarios.Elements("produto"))
            {
                CopiaListaProdutos.Add(new Produto()
                {
                    Categoria = item.Element("categoria").Value,
                    Descricao = item.Element("descricao").Value,
                    PrecoUnitario = Decimal.Parse(item.Element("precounitario").Value),
                    Quantidade = Int32.Parse(item.Element("quantidade").Value)
                });
            }
        }

        private void AplicarFiltro()
        {
            if (pesquisaPorNome == null)
                pesquisaPorNome = "";

            var resultado = CopiaListaProdutos.Where(n => n.Descricao.ToLowerInvariant()
                                .Contains(PesquisaPorNome.ToLowerInvariant().Trim())).ToList();

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

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Produtos)));
        }

        public List<Produto> CopiaListaProdutos;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Produto> Produtos { get; set; } = new ObservableCollection<Produto>();

        private async Task GetProdutos(string paramURL)
        {
            var httpRequest = new HttpClient();
            Stream = await httpRequest.GetStringAsync(paramURL);
        }
    }
}
