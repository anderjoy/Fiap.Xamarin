using Xamarin.Forms;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic
{
    public partial class App : Application
	{
        public static AlunoViewModel alunoViewModel;

		public App ()
		{
            if (alunoViewModel == null)
            {
                alunoViewModel = new AlunoViewModel();
            }

			InitializeComponent();

			MainPage = new NavigationPage(new XF.MVVMBasic.View.AlunoView() { BindingContext = App.alunoViewModel });
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
