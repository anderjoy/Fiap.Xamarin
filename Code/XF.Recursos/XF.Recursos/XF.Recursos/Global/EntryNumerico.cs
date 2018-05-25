using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF.Recursos.Global
{
    public class EntryNumerico : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {            
            bool validar = int.TryParse(sender.Text, out int parsed);
            if (!validar)
            {
                sender.TextColor = Color.Red;
            }
            else
            {
                sender.TextColor = Color.Blue;
            }
        }
    }
}
