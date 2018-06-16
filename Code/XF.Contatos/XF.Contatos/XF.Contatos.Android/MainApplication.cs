using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System;

/// <summary>
/// David Britch is a Developer/Writer at Microsoft, working in the Xamarin organisation, and 
/// has previously spent many years working on projects for different groups at Microsoft. 
/// David has authored and contributed to a range of recent software development publications including 
/// books, guidance documentation, reference implementations, whitepapers, videos, HOLs, and ILT courses. 
/// David has a PhD in Computation, specializing in image and signal processing.
/// https://www.davidbritch.com/2017/11/xamarinforms-25-and-local-context-on.html
/// </summary>

namespace XF.Contatos.Droid
{
    [Application]
    public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        internal static Context CurrentContext { get; private set; }

        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentContext = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {

        }

        public void OnActivityPaused(Activity activity)
        {

        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentContext = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public void OnActivityStarted(Activity activity)
        {
            CurrentContext = activity;
        }

        public void OnActivityStopped(Activity activity)
        {

        }
    }
}