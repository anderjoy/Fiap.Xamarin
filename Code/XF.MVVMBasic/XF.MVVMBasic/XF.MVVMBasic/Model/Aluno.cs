using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XF.MVVMBasic.Model
{
    public class Aluno : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        public string RM { get; set; }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                EventPropertyChanged();
            }
        }

        public string Email { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
