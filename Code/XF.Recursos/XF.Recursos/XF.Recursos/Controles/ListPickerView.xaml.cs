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
	public partial class ListPickerView : ContentPage
	{
        private Dictionary<int, string> cores = new Dictionary<int, string>
        {
            { 1, "#008000" },
            { 2, "#0000FF" },
            { 3, "#FF0000" },
            { 4, "#008000" },
            { 5, "#0000FF" },
            { 6, "#FF0000" },
            { 7, "#008000" },
            { 8, "#0000FF" },
            { 9, "#FF0000" },
            { 10, "#008000" },
            { 11, "#0000FF" },
            { 12, "#FF0000" },
            { 13, "#FFFF00" }
        };

        public ListPickerView()
        {
            InitializeComponent();

            foreach (var item in cores.Values)
            {
                pikCor.Items.Add(item);
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxCor.Color = Color.FromHex(pikCor.SelectedItem.ToString());
        }
    }
}