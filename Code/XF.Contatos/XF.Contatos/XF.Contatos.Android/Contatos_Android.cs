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
        public void GetContatos()
        {
            var context = MainApplication.CurrentContext as Activity;
            var book = new AddressBook(context);


            Task.Run(async () =>
            {
                if (await book.RequestPermission())
                {
                    IList<Contato> contacts = new List<Contato>();
                    foreach (Contact contact in book.ToList().OrderBy(c => c.LastName))
                    {
                        Console.WriteLine("{0} {1}", contact.FirstName, contact.LastName);

                        contacts.Add(new Contato()
                        {
                            Id = contact.Id,
                            Nome = contact.FirstName + " - " + contact.LastName,
                            Telefone = contact.Phones.FirstOrDefault()?.Number
                        });
                    }

                    MessagingCenter.Send<IContatos, IList<Contato>>(this, "contatos", contacts);
                }
            });
        }
    }
}