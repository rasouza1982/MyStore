using System;
using DomainNotificationHelper.Events.Contracts;
using MyStore.Domain.Account.Entities;
using MyStore.SharedKernel.Resources;

namespace MyStore.Domain.Account.Events.UserEvents
{
    public class OnUserRegisteredEvent : IDomainEvent
    {

        public OnUserRegisteredEvent(User user)
        {
            Date = DateTime.Now;
            User = user;
            EmailTitle = EmailTemplates.WelcomeEmailTitle;
            EmailBody = EmailTemplates.WelcomeEmailBody;
        }

        public User User { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public DateTime Date { get; set; }
    }
}