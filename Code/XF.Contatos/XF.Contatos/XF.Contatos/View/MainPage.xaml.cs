using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Contatos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        public MainPage()
		{
            InitializeComponent();
        }

        private async void lstContatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new ContactDetail() { BindingContext = App.contactViewModel });            
        }
    }
}
