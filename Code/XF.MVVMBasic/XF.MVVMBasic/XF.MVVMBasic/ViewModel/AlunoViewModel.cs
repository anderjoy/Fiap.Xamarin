using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel
    {
        public Aluno AlunoModel { get; set; }

        public ObservableCollection<Aluno> Alunos { get; private set; } = new ObservableCollection<Aluno>();
        public Adicionar InserirAluno { get; set; }
        public ICommand OnNovo { get; private set; }

        public AlunoViewModel()
        {
            InserirAluno = new Adicionar(this);
            OnNovo = new Command(Novo);

        }

        public async void AddAluno(Aluno param)
        {
            Alunos.Add(param);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async void Novo()
        {
            AlunoModel = new Aluno();
            await App.Current.MainPage.Navigation.PushAsync(new View.NovoAlunoView() { BindingContext = App.alunoViewModel });
        }

    }

    public class Adicionar : ICommand
    {
        AlunoViewModel alunoVM;
        public Adicionar(AlunoViewModel paramVM )
        {
            alunoVM = paramVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            alunoVM.AddAluno(alunoVM.AlunoModel);
        }
    }
}
