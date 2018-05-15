using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Hello
{
    public class Configuracao
    {
        public bool Rastrear { get; set; }

        public bool Permitir { get; set; }

        public bool Disponibilizar { get; set; }

        public bool EnviarEmail { get; set; }

        public bool ReceberSMS { get; set; }
    }
}
