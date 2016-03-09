using Xamarin.Forms;
using FindMe.ViewModels;

namespace FindMe.Views
{
    public partial class SignInPage
    {
        public SignInViewModel ViewModel
        {
            get { return BindingContext as SignInViewModel; }
            set { BindingContext = value; }
        }
        public SignInPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            ViewModel = new SignInViewModel(Navigation);

            MessagingCenter.Subscribe<SignInViewModel>(this, "RequiredFieldError", sender =>
                {
                    DisplayAlert("Sign In Failed", "Email Address and Event Code are both required.", "Ok");
                });

            MessagingCenter.Subscribe<SignInViewModel>(this, "SignInFailed", sender =>
                {
                    DisplayAlert("Sign In Failed", "Please check the Event Code.", "Ok");
                });

            MessagingCenter.Subscribe<SignInViewModel>(this, "UnexpectedError", sender =>
            {
                DisplayAlert("Error", "An unexpected error occured. Please try again.", "Ok");
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

//            Insights.Track(AppConstants.SignInPage);
        }
    }
}

