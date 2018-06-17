using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF.Contatos.API
{
    public interface IContatos
    {
        void GetContatos();
    }

    public class Contato
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
