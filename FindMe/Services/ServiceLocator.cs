namespace FindMe.Services
{
    public static class ServiceLocator
    {
        private static IEventService _eventService;

        public static IEventService EventService => _eventService ?? (_eventService = new EventService());
    }
}
