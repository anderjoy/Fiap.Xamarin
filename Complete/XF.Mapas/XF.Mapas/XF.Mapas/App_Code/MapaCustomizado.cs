using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace XF.Mapas.App_Code
{
    public class MapaCustomizado : Map
    {
        public CircoNoMapa AreaDemarcada { get; set; }
    }

    public class CircoNoMapa
    {
        public Position Posicao { get; set; }
        public double RaioDemarcado { get; set; }
    }
}
