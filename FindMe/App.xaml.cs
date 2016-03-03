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
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

