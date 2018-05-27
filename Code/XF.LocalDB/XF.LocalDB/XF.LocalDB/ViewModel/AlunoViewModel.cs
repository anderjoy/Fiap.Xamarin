using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SQLite;
using Xamarin.Forms;
using XF.LocalDB.Data;
using XF.LocalDB.Model;
using XF.LocalDB.View.Aluno;

namespace XF.LocalDB.ViewModel
{
    public class AlunoViewModel
    {
        private readonly SQLiteConnection _database;
        private static object locker = new object();

        public Aluno AlunoModel { get; set; }

        public ICommand OnNovoCMD { get; private set; }
        public ICommand OnEditarAlunoCMD { get; private set; }
        public ICommand OnSalvarCMD { get; private set; }
        public ICommand OnCancelarCMD { get; private set; }
        public ICommand OnRemoverCDM { get; private set; }

        public AlunoViewModel()
        {
            _database = DependencyService.Get<ISQLite>().GetConexao();
            _database.CreateTable<Aluno>();

            OnNovoCMD = new Command(() =>
            {
                AlunoModel = new Aluno();

                App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
            });

            OnEditarAlunoCMD = new Command((object param) =>
            {
                AlunoModel = GetAluno((param as Aluno).Id);

                App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
            });

            OnCancelarCMD = new Command(() =>
            {
                App.Current.MainPage.Navigation.PopAsync();
            });

            OnSalvarCMD = new Command(() =>
            {
                SalvarAluno(AlunoModel);
                RefreshListAlunos();
                App.Current.MainPage.Navigation.PopAsync();
            });

            OnRemoverCDM = new Command((object param) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var _aluno = param as Aluno;

                    var result = await App.Current.MainPage.DisplayAlert("Atenção!", $"Deseja remover o aluno \"{_aluno.Nome}\"?", "Sim", "Não");

                    if (result)
                    {
                        RemoverAluno(_aluno.Id);
                        RefreshListAlunos();
                    }
                });
                                
            });

            RefreshListAlunos();
        }

        private void RefreshListAlunos()
        {
            lock (locker)
            {
                var alunos = (from c in _database.Table<Aluno>()
                              select c).ToList();

                Alunos.Clear();
                foreach (var item in alunos)
                {
                    Alunos.Add(item);
                }
            }          
        }

        public ObservableCollection<Aluno> Alunos { get; private set; } = new ObservableCollection<Aluno>();

        public int SalvarAluno(Aluno aluno)
        {
            lock (locker)
            {
                if (aluno.Id != 0)
                {
                    _database.Update(aluno);
                    return aluno.Id;
                }
                else return _database.Insert(aluno);
            }
        }

        public Aluno GetAluno(int Id)
        {
            lock (locker)
            {
                // return database.Query<Aluno > ("SELECT * FROM [Aluno] WHERE [Id] = " + Id);
                return _database.Table<Aluno>().Where(c => c.Id == Id).FirstOrDefault();
            }
        }
        public int RemoverAluno(int Id)
        {
            lock (locker)
            {
                return _database.Delete<Aluno>(Id);
            }
        }
    }
}
