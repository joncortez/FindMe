using System;
using System.Collections.Generic;
using FindMe.ViewModels;
using Xamarin.Forms;

namespace FindMe.Views
{
    public partial class EventPage : ContentPage
    {
        public EventViewModel ViewModel
        {
            get { return BindingContext as EventViewModel; }
            set { BindingContext = value; }
        }

        public EventPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            ViewModel = new EventViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Insights.Track(AppConstants.EventPage);
        }
    }
}

