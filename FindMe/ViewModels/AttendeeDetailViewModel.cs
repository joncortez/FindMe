using System.Threading.Tasks;
using FindMe.Models;
using FindMe.Services;
using FindMe.Views;
using Xamarin.Forms;
using System.Windows.Input;

namespace FindMe.ViewModels
{
    public class AttendeeDetailViewModel : BaseViewModel
    {
        private readonly IEventService _eventService;
        private readonly INavigation _navigation;

        public Attendee Attendee { get; private set; }

        public AttendeeDetailViewModel(INavigation navigation, Attendee attendee)
        {
            _navigation = navigation;
            _eventService = ServiceLocator.EventService;
            Attendee = attendee;
        }

        private Command _findEventCommand;

        public ICommand FindEventCommand
        {
            get { return _findEventCommand ?? (_findEventCommand = new Command(async () => await ExecuteFindEventCommand())); }
        }

        private async Task ExecuteFindEventCommand()
        {
            var page = new FindAttendeePage(Attendee);
            await _navigation.PushAsync(page);
        }
    }
}
