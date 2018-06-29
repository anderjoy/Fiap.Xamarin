using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Contatos.App_Code
{
    public interface ILocalizacao
    {
        void GetCoordenada();
    }

    public class Coordenada
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
