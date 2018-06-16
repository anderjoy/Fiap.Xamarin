using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Recursos.GPS
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
