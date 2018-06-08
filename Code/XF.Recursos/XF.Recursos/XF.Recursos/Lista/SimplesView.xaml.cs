using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Recursos.Lista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SimplesView : ContentPage
	{
        public SimplesView()
        {
            InitializeComponent();

            var cursos = new[]
            {
                "Desenvolvimento de aplicativos com Xamarin",
                "Introdução a Big Data & Analytics",
                "Certificação TOGAF Nível 1"
            };

            lstCursos.ItemsSource = cursos;
        }
    }
}