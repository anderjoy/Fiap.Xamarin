using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Hello
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        public HomePage()
        {
            InitializeComponent();

            Button goBackButton = new Button()
            {
                Text = "<- Voltar",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            goBackButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            this.rootLayout.Children.Add(goBackButton);
        }

        void OnAlterarIntensidadeSlider(Object sender, EventArgs e)
        {
            var vermelho = sliderVermelho.Value;
            var verde = sliderVerde.Value;
            var azul = sliderAzul.Value;

            boxviewCor.Color = Color.FromRgb(vermelho, verde, azul);
        }
    }
}