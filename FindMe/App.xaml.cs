using System.Diagnostics;
using Estimotes;
using Xamarin.Forms;
using FindMe.Views;

namespace FindMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // The root page of your application
            var mainPage = new SignInPage();
            var navPage = new NavigationPage(mainPage)
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#747474")
            };
            MainPage = navPage;
        }

        protected override void OnStart()
        {
            base.OnStart();
            EstimoteManager.Instance.Initialize()
                .ContinueWith(x => OnBeaconMgrInit(x.Result));
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            EstimoteManager.Instance.StopAllRanging();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static void OnBeaconMgrInit(BeaconInitStatus status)
        {
            Debug.WriteLine($"Beacon Init Status: {status}");
        }
    }
}

