using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Recursos.Global;

namespace XF.Recursos.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
        public ListView ListView { get { return lstMenu; } }
        public MenuView()
        {
            InitializeComponent();

            ObservableCollection<OpcoesMenu> menuItems = new ObservableCollection<OpcoesMenu>();
            menuItems.Add(new OpcoesMenu
            {
                Descricao = "Home",
                Icone = "Home.png",
                TargetType = typeof(HomeView)
            });
            menuItems.Add(new OpcoesMenu
            {
                Descricao = "Configurações",
                Icone = "Engine.png",
                TargetType = typeof(ConfigView)
            });

            lstMenu.ItemsSource = menuItems;
        }
    }
}