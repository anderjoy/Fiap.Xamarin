using System;
using System.Collections.Generic;
using System.Text;

namespace XF.Recursos.Global
{
    public class MessagingViewModel
    {
        public enum Navegacao
        {
            Inserir,
            Alterar,
            Remover,
            Visualizar
        }
        public Navegacao TipoNavegacao { get; set; } = new Navegacao();
    }
}
