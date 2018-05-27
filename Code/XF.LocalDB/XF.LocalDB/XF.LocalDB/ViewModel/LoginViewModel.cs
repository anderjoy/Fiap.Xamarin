using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public usuario LoginModel { get; private set; } = new usuario();

        public ICommand OnLoginCMD { get; set; }

        public LoginViewModel()
        {
            OnLoginCMD = new Command(LoginAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoginAction()
        {
            using (HttpClient http = new HttpClient())
            {
                var listUserContent = await http.GetAsync(@"http://wopek.com/xml/usuarios.xml");

                var listUserXML = await listUserContent.Content.ReadAsStringAsync();

                XmlSerializer serializer = new XmlSerializer(typeof(List<usuario>), new XmlRootAttribute("usuarios"));
                StringReader stringReader = new StringReader(listUserXML);
                IList<usuario> listUser = (List<usuario>)serializer.Deserialize(stringReader);

                var user = listUser.FirstOrDefault(x => x.username == LoginModel.username && x.password == LoginModel.password);

                if (user != null)
                {
                    LoginModel.password = "";                    

                    App.Current.MainPage = new NavigationPage(new View.Aluno.MainPage() { BindingContext = App.AlunoVM });
                }
                else
                {
                    LoginModel.username = "";
                    LoginModel.password = "";                    

                    await App.Current.MainPage.DisplayAlert("Login", "Usuário/Senha inválido", "OK");
                }

                NotifyProp();
            }            
        }

        private void NotifyProp()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoginModel"));
        }
    }
}
