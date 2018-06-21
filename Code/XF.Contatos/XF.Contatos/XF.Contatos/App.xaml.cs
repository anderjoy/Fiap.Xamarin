using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.Contatos.ViewModel;

namespace XF.Contatos
{
	public partial class App : Application
	{
        public static ContactViewModel contactViewModel;

		public App ()
		{
            if (contactViewModel == null)
            {
                contactViewModel = new ContactViewModel();
            }

			InitializeComponent();

			MainPage = new NavigationPage(new View.MainPage() { BindingContext = contactViewModel });
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
