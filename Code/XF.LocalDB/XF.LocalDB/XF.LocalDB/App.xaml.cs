using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.LocalDB.Model;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Login.LoginView() { BindingContext = LoginVM });
        }

        private static AlunoViewModel _alunoVM;
        public static AlunoViewModel AlunoVM
        {
            get
            {
                if (_alunoVM == null)
                {
                    _alunoVM = new AlunoViewModel();
                }
                return _alunoVM;
            }
        }

        private static LoginViewModel _loginVM;
        public static LoginViewModel LoginVM
        {
            get
            {
                if (_loginVM == null)
                {
                    _loginVM = new LoginViewModel();
                }

                return _loginVM;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
