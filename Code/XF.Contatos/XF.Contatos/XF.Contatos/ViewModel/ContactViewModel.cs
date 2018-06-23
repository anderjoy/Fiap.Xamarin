using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Contatos.API;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OnCallContact { get; private set; }

        public ICommand TakePhotoCommand { get; set; }

        public ICommand ShowLocationCommand { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    CarregarContatos();

                    IsRefreshing = false;
                });
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                EventPropertyChanged();
            }
        }

        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        private Contato _contatoSelected;
        public Contato contatoSelected
        {
            get
            {
                return _contatoSelected;
            }
            set
            {
                if (_contatoSelected != value)
                {
                    _contatoSelected = value;
                    EventPropertyChanged(nameof(contatoSelected));
                }
            }
        }

        public Coordenada Coordenada { get; private set; } = new Coordenada();

        public ContactViewModel()
        {
            OnCallContact = new Command(CallContact);
            TakePhotoCommand = new Command(ActionTakePhotoCommand);
            ShowLocationCommand = new Command(ActionShowLocationCommand);

            CarregarContatos();
            CarregaGeoLocation();
        }

        private void ActionTakePhotoCommand()
        {
            ITakePhoto photo = DependencyService.Get<ITakePhoto>();

            if (photo != null)
            {
                photo.GetPhotoFromCamera();

                MessagingCenter.Subscribe<ITakePhoto, byte[]>(this, "photo",
                    (objeto, file) =>
                    {
                        contatoSelected.Thumbnail = file;
                        EventPropertyChanged(nameof(contatoSelected));
                    });
            }
        }

        private void CarregarContatos()
        {
            var contatosService = DependencyService.Get<IContatos>();
            if (contatosService != null)
            {
                contatosService.GetContatos();

                MessagingCenter.Subscribe<IContatos, IList<Contato>>(this, "contatos",
                    (objeto, contatos) =>
                    {
                        var Contatos = App.contactViewModel.Contatos;

                        Contatos.Clear();
                        foreach (var item in contatos)
                        {
                            Contatos.Add(item);
                        }
                    });
            }
        }

        private void CarregaGeoLocation()
        {
            ILocalizacao localizacao = DependencyService.Get<ILocalizacao>();
            if (localizacao != null)
            {
                localizacao.GetCoordenada();

                MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordenada",
                    (objeto, geo) =>
                    {
                        Coordenada.Latitude = geo.Latitude;
                        Coordenada.Longitude = geo.Longitude;

                        EventPropertyChanged(nameof(Coordenada));
                    });
            }
        }

        private void ActionShowLocationCommand()
        {
            ILocalizacao localizacao = DependencyService.Get<ILocalizacao>();

            if (localizacao != null)
            {
                localizacao.GoToCoordenada(Coordenada);
            }
        }

        public async void CallContact(object param)
        {
            Contato contact = (param as Contato);

            if (!string.IsNullOrEmpty(contact.Telefone))
            {
                if (await App.Current.MainPage.DisplayAlert("Ligando...", "Ligar para " + contact.Telefone + "?", "Sim", "Não"))
                {
                    var ligar = DependencyService.Get<ILigar>();
                    if (ligar != null) ligar.Discar(contact.Telefone);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Aviso!", "Esse contato não possui telefone cadastrado", "Ok");
            }
        }

        public void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
