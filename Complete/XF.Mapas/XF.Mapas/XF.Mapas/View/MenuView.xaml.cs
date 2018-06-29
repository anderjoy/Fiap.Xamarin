using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Mapas.App_Code;

namespace XF.Mapas.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
        public ListView ListView { get { return lstMenu; } }
        public MenuView()
        {
            InitializeComponent();

            ObservableCollection<ListaMenu> menuItems = new ObservableCollection<ListaMenu>();
            menuItems.Add(new ListaMenu
            {
                Descricao = "Mapa",
                TargetType = typeof(MapaView)
            });
            menuItems.Add(new ListaMenu
            {
                Descricao = "Controles básicos",
                TargetType = typeof(ControleView)
            });
            menuItems.Add(new ListaMenu
            {
                Descricao = "Localização",
                TargetType = typeof(LocalizacaoView)
            });
            menuItems.Add(new ListaMenu
            {
                Descricao = "Marcação (Pin)",
                TargetType = typeof(MarcarView)
            });
            menuItems.Add(new ListaMenu
            {
                Descricao = "Raio Demarcado",
                TargetType = typeof(MapaDemarcadoView)
            });
            lstMenu.ItemsSource = menuItems;
        }
    }
}