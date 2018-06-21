using Android.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Contacts;
using Xamarin.Forms;
using XF.Contatos.API;
using XF.Contatos.Droid;
using XF.Contatos.Model;

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
                    foreach (Contact bookContact in book.ToList().OrderBy(c => c.LastName))
                    {
                        Console.WriteLine("{0} {1}", bookContact.FirstName, bookContact.LastName);

                        var image = bookContact.GetThumbnail();
                        byte[] imgSrc = null;

                        if (image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, ms);
                                ms.Seek(0L, SeekOrigin.Begin);

                                imgSrc = ms.ToArray();
                            }
                        }                       

                        contacts.Add(new Contato()
                        {
                            Id = bookContact.Id,
                            Nome = bookContact.FirstName + " - " + bookContact.LastName,
                            Telefone = bookContact.Phones.FirstOrDefault()?.Number,
                            Thumbnail = imgSrc
                        });
                    }

                    MessagingCenter.Send<IContatos, IList<Contato>>(this, "contatos", contacts);
                }
            });
        }
    }
}