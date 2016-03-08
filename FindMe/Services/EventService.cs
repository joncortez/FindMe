using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FindMe.Configuration;
using FindMe.Models;
using Newtonsoft.Json;

namespace FindMe.Services
{
    public class EventService : IEventService
    {
        public Event Event { get; private set; }

        public async Task LoadEvent(string eventCode)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{AppConstants.AwsBaseSvcUrl}/events/findByCode/{eventCode}";
                    var json = await client.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<Event>(json);
                    Event = result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<Attendee> GetAttendeeByEmail(string email)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{AppConstants.AwsBaseSvcUrl}/attendees/findByEmail/{email}";
                    var json = await client.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<Attendee>(json);
                    return result;
                }
            }
            catch (HttpRequestException hre)
            {
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<Attendee> CreateAttendee(Attendee newAttendee)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{AppConstants.AwsBaseSvcUrl}/attendees";
                    var contentToPost = new StringContent(JsonConvert.SerializeObject(newAttendee), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, contentToPost);
                    var json = response.Content.ReadAsStringAsync().Result;
                    var attendee = JsonConvert.DeserializeObject<Attendee>(json);

                    return attendee;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<EventAttendee> RegisterAttendee(EventAttendee newEventAttendee)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{AppConstants.AwsBaseSvcUrl}/eventattendees";
                    var contentToPost = new StringContent(JsonConvert.SerializeObject(newEventAttendee), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, contentToPost);
                    var json = response.Content.ReadAsStringAsync().Result;
                    var eventAttendee = JsonConvert.DeserializeObject<EventAttendee>(json);

                    return eventAttendee;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<IList<Attendee>> GetEventAttendees(string eventId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{AppConstants.AwsBaseSvcUrl}/attendees/findByEvent/{eventId}";
                    var json = await client.GetStringAsync(url);
                    var result = JsonConvert.DeserializeObject<IList<Attendee>>(json);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
