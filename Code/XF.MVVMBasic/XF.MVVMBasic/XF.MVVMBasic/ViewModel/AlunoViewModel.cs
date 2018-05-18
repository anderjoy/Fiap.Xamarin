using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        private Aluno _alunoModel;

        public Aluno AlunoModel
        {
            get { return _alunoModel; }
            set
            {
                _alunoModel = value;

                _alunoModel.PropertyChanged += EventPropertyChanged;
            }
        }

        public ObservableCollection<Aluno> Alunos { get; private set; } = new ObservableCollection<Aluno>();
        public ICommand InserirAluno { get;  private set; }
        public ICommand OnNovo { get; private set; }
        public ICommand OnRemoverAluno { get; private set; }

        public AlunoViewModel()
        {
            InserirAluno = new Command(ExecuteNovoAluno, CanExecuteNovoAluno);            
            OnNovo = new Command(Novo);
            OnRemoverAluno = new Command(ExecuteRemoverAluno);
        }

        public async void ExecuteNovoAluno(object parameter)
        {
            Alunos.Add(AlunoModel);
            await App.Current.MainPage.Navigation.PopAsync();            
        }

        public bool CanExecuteNovoAluno(object parameter)
        {
            return _alunoModel == null ? false : !string.IsNullOrEmpty(_alunoModel.Nome);
        }

        public void ExecuteRemoverAluno(object parameter)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await App.Current.MainPage.DisplayAlert("Atenção!", $"Deseja remover o aluno \"{(parameter as Aluno).Nome}\"?", "Sim", "Não");

                if (result)
                {
                    Alunos.Remove((parameter as Aluno));
                }
            });
        }

        private void EventPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (InserirAluno as Command).ChangeCanExecute();            
        }

        public async void Novo()
        {
            AlunoModel = new Aluno();

            await App.Current.MainPage.Navigation.PushAsync(new View.NovoAlunoView() { BindingContext = App.alunoViewModel });
        }
    }
}
