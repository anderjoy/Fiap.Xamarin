using Android.Content;
using Android.Net;
using Android.Telephony;
using System.Linq;
using Xamarin.Forms;
using XF.Contatos.App_Code;
using XF.Contatos.Droid.App_Code;

[assembly: Dependency(typeof(Telefone_Android))]
namespace XF.Contatos.Droid.App_Code
{
    public class Telefone_Android : ITelefone
    {
        public bool Ligar(string numero)
        {
            var context = Forms.Context;
            if (context == null)
                return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + numero));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any()) return true;

            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;
        }
    }
}