using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XF.Contatos.API
{
    public interface IContatos
    {
        Task<IEnumerable<Contato>> GetContatos();
    }

    public class Contato
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
