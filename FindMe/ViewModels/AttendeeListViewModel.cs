using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FindMe.Models;
using FindMe.Services;
using Xamarin.Forms;

namespace FindMe.ViewModels
{
    public class AttendeeListViewModel : BaseViewModel
    {
        private readonly IEventService _eventService;
        private readonly INavigation _navigation;

        public ObservableCollection<Attendee> Attendees { get; set; }

        public AttendeeListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _eventService = ServiceLocator.EventService;

            Attendees = new ObservableCollection<Attendee>(_eventService.Attendees);
        }

        private Command _refreshCommand;

        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand(), () => !IsRefreshing));
            }
        }

        private async Task ExecuteRefreshCommand()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            RefreshCommand.ChangeCanExecute();

            await _eventService.LoadEventAttendees(_eventService.Event.Id);
            if (_eventService.Attendees != null)
            {
                Attendees.Clear();
                foreach (var attendee in _eventService.Attendees)
                {
                    Attendees.Add(attendee);
                }
            }

            IsRefreshing = false;
            RefreshCommand.ChangeCanExecute();
        }
    }
}
