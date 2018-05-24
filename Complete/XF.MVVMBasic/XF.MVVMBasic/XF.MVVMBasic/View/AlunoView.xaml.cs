using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlunoView : ContentPage
    {
        public AlunoView()
        {
            InitializeComponent();
        }
    }
}
