using System.Collections.Generic;
using System.Threading.Tasks;
using FindMe.Models;

namespace FindMe.Services
{
    public interface IEventService
    {
        Event Event { get; }
        Task LoadEvent(string eventCode);
        Task<Attendee> RegisterAttendee(string eventId, string email);
        Task<Attendee> GetAttendeeByEmail(string email);
        Task<Attendee> CreateAttendee(Attendee newAttendee);
        Task<EventAttendee> CreateEventAttendee(EventAttendee newEventAttendee);
        Task<IList<Attendee>> GetEventAttendees(string eventId);
    }
}