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
	public partial class ProgressoView : ContentPage
	{
        private bool IsProgress;

        public ProgressoView()
        {
            InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    indProgresso.Color = Color.Blue;
                    pgrProgresso.BackgroundColor = Color.Blue;
                    break;
                case Device.Android:
                    indProgresso.Color = Color.YellowGreen;
                    pgrProgresso.BackgroundColor = Color.YellowGreen;
                    break;
                default:
                    break;
            }
            indProgresso.IsRunning = false;
            indProgresso.VerticalOptions = LayoutOptions.Center;
        }

        private void IsIndicador_Clicked(object sender, EventArgs e)
        {
            indProgresso.IsRunning = !indProgresso.IsRunning;
            if (!indProgresso.IsRunning) btnIndIniciar.Text = "Start";
            else btnIndIniciar.Text = "Stop";
        }

        bool TimerProgresso()
        {
            pgrProgresso.Progress += 0.01;
            if (pgrProgresso.Progress >= 1d)
            {
                pgrProgresso.Progress = 0d;
                return false;
            }

            return IsProgress && pgrProgresso.Progress != 1;
        }

        private void IsProgresso_Clicked(object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerProgresso);
            IsProgress = true;
        }

        private void IsProgressoStop_Clicked(object sender, EventArgs e)
        {
            IsProgress = false;
        }
    }
}