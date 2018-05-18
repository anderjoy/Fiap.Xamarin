using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerView : ContentPage
	{
        public PickerView()
        {
            InitializeComponent();

            dtpData.MinimumDate = new DateTime(2017, 10, 1);
            dtpData.MaximumDate = new DateTime(2018, 12, 31);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DateTime data = dtpData.Date + tmpHorario.Time;
            await DisplayAlert("Evento", data.ToString("dd/MM/yyyy hh:mm tt"), "OK");
        }
    }
}