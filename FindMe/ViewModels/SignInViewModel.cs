using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using FindMe.Models;
using FindMe.Services;
using FindMe.Views;

namespace FindMe.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        private readonly IEventService _eventService;
        private readonly INavigation _navigation;

        public SignInViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _eventService = ServiceLocator.EventService;

            //if (Settings.EventCode != null)
            //    _eventCode = Settings.EventCode;

            //if (Settings.UserEmail != null)
            //    _email = Settings.UserEmail;
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
                _email = _email.Trim();
                _eventCode = _eventCode.Trim();
                if (_email.Length == 0 || _eventCode.Length == 0)
                {
                    // Send message to inform user that both email and code are required
                    MessagingCenter.Send(this, "RequiredFieldError");

                    return;
                }

                // Call service to load the data for the event
                await _eventService.LoadEvent(_eventCode);

                if (_eventService.Event != null)
                {
                    var eventId = _eventService.Event.Id;
                    var eventAttendee = await _eventService.RegisterAttendee(eventId, _email);
                    if (eventAttendee != null)
                    {
                        var eventPage = new EventPage();
                        await _navigation.PushAsync(eventPage);

                        return;
                    }
                }

                // Something went wrong...
                MessagingCenter.Send(this, "UnexpectedError");
            }
            catch (Exception ex)
            {
                // Send message to inform user that Sign In failed
                MessagingCenter.Send(this, "SignInFailed");
            }
            finally
            {
                IsBusy = false;
            }
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

