﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FindMe.Services;
using FindMe.Views;
using Xamarin.Forms;

namespace FindMe.ViewModels
{
    public class EventViewModel : BaseViewModel
    {
        private readonly IEventService _eventService;
        private readonly INavigation _navigation;

        public EventViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _eventService = ServiceLocator.EventService;

            var eventInfo = _eventService.Event;

            _backgroundImgUrl = eventInfo.BackgroundImageUrl;
            _title = eventInfo.WelcomeMessage;
        }

        private string _backgroundImgUrl;
        public string BackgroundImgUrl
        {
            get { return _backgroundImgUrl; }
            set { _backgroundImgUrl = value; OnPropertyChanged("BackgroundImgUrl"); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }

        private Command _joinEventCommand;

        public ICommand JoinEventCommand
        {
            get { return _joinEventCommand ?? (_joinEventCommand = new Command(async () => await ExecuteJoinEventCommand())); }
        }

        private async Task ExecuteJoinEventCommand()
        {
            try
            {
                await _eventService.LoadEventAttendees(_eventService.Event.Id);
                var listPage = new AttendeeListPage();
                await _navigation.PushAsync(listPage);
            }
            catch (Exception)
            {
                MessagingCenter.Send(this, "LoadAttendeesFailed");
            }
        }
    }
}
