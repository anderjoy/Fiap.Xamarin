using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.MVVMBasic.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoView : ContentPage
    {
        public NovoAlunoView()
        {
            InitializeComponent();
        }        
    }
}