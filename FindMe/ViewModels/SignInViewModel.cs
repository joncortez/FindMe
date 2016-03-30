using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using FindMe.Services;
using FindMe.Views;
using System.Text.RegularExpressions;

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
                _email = _email.Trim();
                _eventCode = _eventCode.Trim();
                if (_email.Length == 0 || _eventCode.Length == 0)
                {
                    // Send message to inform user that both email and code are required
                    MessagingCenter.Send(this, "RequiredFieldError");

                    return;
                }

                const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                
                if (!Regex.IsMatch(_email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    // Send message to inform user that email has invalid format
                    MessagingCenter.Send(this, "InvalidEmailFormat");
                
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
    }
}



