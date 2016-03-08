using System.Collections.Generic;
using System.Threading.Tasks;
using FindMe.Models;

namespace FindMe.Services
{
    public interface IEventService
    {
        Event Event { get; }
        Task LoadEvent(string eventCode);
        Task<Attendee> GetAttendeeByEmail(string email);
        Task<Attendee> CreateAttendee(Attendee newAttendee);
        Task<EventAttendee> RegisterAttendee(EventAttendee newEventAttendee);
        Task<IList<Attendee>> GetEventAttendees(string eventId);
    }
}