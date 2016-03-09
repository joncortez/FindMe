using FindMe.Models;
using FindMe.ViewModels;
using Xamarin.Forms;

namespace FindMe.Views
{
    public partial class FindAttendeePage : ContentPage
    {
        public RangingViewModel ViewModel
        {
            get { return BindingContext as RangingViewModel; }
            set { BindingContext = value; }
        }

        public FindAttendeePage(Attendee attendee)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            ViewModel = new RangingViewModel(attendee);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.Cleanup();
        }
    }
}
