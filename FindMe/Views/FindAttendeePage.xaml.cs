using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public FindAttendeePage()
        {
            InitializeComponent();

            ViewModel = new RangingViewModel();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModel.Cleanup();
        }
    }
}
