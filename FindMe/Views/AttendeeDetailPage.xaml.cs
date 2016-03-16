using FindMe.Models;
using FindMe.ViewModels;
using Xamarin.Forms;

namespace FindMe.Views
{
    public partial class AttendeeDetailPage : ContentPage
    {
        public AttendeeDetailViewModel ViewModel
        {
            get { return BindingContext as AttendeeDetailViewModel; }
            set { BindingContext = value; }
        }

        public AttendeeDetailPage(Attendee attendee)
        {
            InitializeComponent();

            var isNavBarVisible = (Device.OS == TargetPlatform.iOS);
            NavigationPage.SetHasNavigationBar(this, isNavBarVisible);
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            ViewModel = new AttendeeDetailViewModel(Navigation, attendee);
        }
    }
}
