using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace FindMe.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
//        private readonly ITastingService _tastingService;
        private readonly INavigation _navigation;

        public SignInViewModel(INavigation navigation)
        {
            _navigation = navigation;
//            _tastingService = ServiceLocator.TastingService;
//
//            if (Settings.EventCode != null)
//                _eventCode = Settings.EventCode;
//
//            if (Settings.UserEmail != null)
//                _email = Settings.UserEmail;
        }

        private string _eventCode;
        public string EventCode
        {
            get { return _eventCode; }
            set { _eventCode = value; OnPropertyChanged("EventCode"); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }

        private Command _signInCommand;

        public ICommand SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new Command(async () => await ExecuteSignInCommand())); }
        }

        private async Task ExecuteSignInCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
//                SetupServiceProviderSettings(_eventCode);


                if (_email.Trim().Length == 0 || _eventCode.Trim().Length == 0)
                {
                    // Send message to inform user that both email and code are required
                    MessagingCenter.Send(this, "RequiredFieldError");

                    return;
                }

//                // Call service to load the data for the tasting
//                await _tastingService.LoadTastingEvent(_eventCode);
//
//                // Register user if successful
//                if (_tastingService.TastingEvent != null)
//                {
//                    var tastingId = _tastingService.TastingEvent.Info.Id;
//                    var user = await _tastingService.RegisterUser(tastingId, _email);
//
//                    SaveSignInInfo(_eventCode, user);
//
//                    // Identify the device user
//                    var userInfo = new Dictionary<string, string>
//                    {
//                        {"EventCode", _eventCode},
//                        {"Email", user.Email}
//                    };
//                    Insights.Identify(user.Email, userInfo);
//                }
            }
            catch (Exception ex)
            {
//                // Log error in Xamarin.Insights
//                Insights.Report(ex, Insights.Severity.Error);

                // Send message to inform user that Sign In failed
                MessagingCenter.Send(this, "SignInFailed");

                return;
            }
            finally
            {
                IsBusy = false;
            }

            var eventPage = new EventPage();
            await _navigation.PushAsync(eventPage);
        }

//        private void SetupServiceProviderSettings(string eventCode)
//        {
//
//
//            if (_eventCode.EndsWith("1"))
//            {
//                Settings.ServiceURL = AppConstants.AWSTastingBaseSvcUrl;
//                Settings.DisplaySurvey = false;
//            }
//            else
//            {
//                Settings.ServiceURL = AppConstants.AzureBaseSvcUrl;
//                Settings.DisplaySurvey = true;
//            }
//
//
//
//        }
//
//        private static void SaveSignInInfo(string eventCode, TastingUser user)
//        {
//            var clearCachedVotes = false;
//
//            if (Settings.EventCode != null && Settings.UserEmail != null)
//            {
//                if (!String.Equals(eventCode, Settings.EventCode, StringComparison.CurrentCultureIgnoreCase))
//                    clearCachedVotes = true;
//
//                if (!String.Equals(user.Email, Settings.UserEmail, StringComparison.CurrentCultureIgnoreCase))
//                    clearCachedVotes = true;
//            }
//
//            Settings.EventCode = eventCode;
//            Settings.UserEmail = user.Email;
//            Settings.UserId = user.Id;
//
//            if (clearCachedVotes)
//                Settings.VotesCastedJson = null;
//        }
    }

}

