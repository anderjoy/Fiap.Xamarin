using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.View;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        #region Propriedades
        public Aluno AlunoModel { get; set; }
        public ObservableCollection<Aluno> Alunos { get; set; } = new ObservableCollection<Aluno>();
        
        // UI Events
        public OnAdicionarAlunoCMD OnAdicionarAlunoCMD { get; }
        public OnRemoverAlunoCMD OnDeleteAlunoCMD { get; }
        public ICommand OnNovoCMD { get; private set; }
        public ICommand OnSairCMD { get; private set; }
        #endregion

        public AlunoViewModel()
        {
            OnAdicionarAlunoCMD = new OnAdicionarAlunoCMD(this);
            OnDeleteAlunoCMD = new OnRemoverAlunoCMD(this);
            OnSairCMD = new Command(OnSair);
            OnNovoCMD = new Command(OnNovo);
        }

        public void Adicionar(Aluno paramAluno)
        {
            try
            {
                if (paramAluno == null)
                    throw new Exception("Usuário inválido");

                paramAluno.Id = Guid.NewGuid();
                Alunos.Add(paramAluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
            }
        }

        public async void Remover(Aluno paramAluno)
        {
            bool removerAluno = await (App.Current.MainPage.DisplayAlert("Remover"
                , string.Format("Tem certeza que deseja remover o aluno: {0}"
                , paramAluno.Nome)
                , "Sim", "Não"));

            try
            {
                if (removerAluno)
                {
                    Alunos.Remove(paramAluno);
                }
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Falhou", "Desculpe, ocorreu um erro inesperado =(", "OK");
            }
        }

        private async void OnSair()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnNovo()
        {
            // App.AlunoVM.AlunoModel.Nome = App.AlunoVM.AlunoModel.Email = App.AlunoVM.AlunoModel.RM = string.Empty;
            App.AlunoVM.AlunoModel = new Aluno();
            await App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class OnAdicionarAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnAdicionarAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => ((parameter != null) && (!string.IsNullOrWhiteSpace(((Aluno)parameter).Nome)));
        public void Execute(object parameter)
        {
            alunoVM.Adicionar(parameter as Aluno);
        }
    }

    public class OnRemoverAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnRemoverAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            alunoVM.Remover(parameter as Aluno);
        }
    }
}
