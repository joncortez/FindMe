using FindMe.Models;
using FindMe.ViewModels;
using Xamarin.Forms;

namespace FindMe.Views
{
    public partial class AttendeeListPage : ContentPage
    {
        public AttendeeListViewModel ViewModel
        {
            get { return BindingContext as AttendeeListViewModel; }
            set { BindingContext = value; }
        }

        public AttendeeListPage()
        {
            InitializeComponent();

            var isNavBarVisible = (Device.OS == TargetPlatform.iOS);
            NavigationPage.SetHasNavigationBar(this, isNavBarVisible);
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            ViewModel = new AttendeeListViewModel(Navigation);

            ItemsListView.ItemTapped += (sender, args) =>
            {
                if (ItemsListView.SelectedItem == null)
                    return;

                var detailsPage = new AttendeeDetailPage(args.Item as Attendee);
                Navigation.PushAsync(detailsPage);

                ItemsListView.SelectedItem = null;
            };
        }
    }
}
