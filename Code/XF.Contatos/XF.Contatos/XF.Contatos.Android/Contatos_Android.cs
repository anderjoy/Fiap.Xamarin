using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Contacts;
using Xamarin.Forms;
using XF.Contatos.API;
using XF.Contatos.Droid;

[assembly: Dependency(typeof(Contatos_Android))]
namespace XF.Contatos.Droid
{
    public class Contatos_Android : IContatos
    {
        public async Task<IEnumerable<Contato>> GetContatos()
        {
            var context = MainApplication.CurrentContext as Activity;
            var book = new AddressBook(context);

            if (!await book.RequestPermission())
            {
                Console.WriteLine("Permisão negada");
                return null;
            }

            IList<Contato> contacts = new List<Contato>();
            foreach (Contact contact in book.OrderBy(c => c.LastName))
            {
                Console.WriteLine("{0} {1}", contact.FirstName, contact.LastName);

                contacts.Add(new Contato()
                {
                    Nome = contact.FirstName + " - " + contact.LastName,
                    Telefone = contact.Phones.FirstOrDefault()?.Number
                });
            }

            return contacts;
        }
    }
}