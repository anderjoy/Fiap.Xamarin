using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.Recursos
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        #region Controles
        private async void btnEditor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Controles.EditorView());
        }

        private async void btnPicker_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Controles.ListPickerView());
        }

        private async void btnData_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Controles.PickerView());
        }

        private async void btnProgresso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Controles.ProgressoView());
        }

        private async void btnStepper_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Controles.StepperView());
        }

        private async void btnSimples_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.SimplesView());
        }
        #endregion

        #region Estilos
        private async void btnGlobal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.GeralView());
        }

        private async void btnDinamico_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.DinamicoView());
        }

        private async void btnTriggers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Estilo.TriggersView());
        }
        #endregion

        #region Lista
        private async void btnListSimples_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.SimplesView());
        }

        private async void btnListClasse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ClassView());
        }

        private async void btnListProdutos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ProdutoView());
        }
        private async void btnListaCards_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lista.ListaCards());
        }
        #endregion

    }
}
