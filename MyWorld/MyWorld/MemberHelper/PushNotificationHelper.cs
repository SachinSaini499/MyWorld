using AzurePushNotification.Plugin;
using AzurePushNotification.Plugin.Abstractions;
using MyWorld.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.MemberHelper
{
  public  class PushNotificationHelper
    {
 
        public PushNotificationHelper()
        {           
            
        }

        public void getNotification()
        {
            PushNotificationCredentials.Tags = new string[] { "test1", "dev", "prod", "phones" };

            PushNotificationCredentials.GoogleApiSenderId = PrismData.PushNotification.senderId;
            PushNotificationCredentials.AzureNotificationHubName = PrismData.PushNotification.azureNotificationName;
            PushNotificationCredentials.AzureListenConnectionString = PrismData.PushNotification.azureListenConnectionString;

            PushNotificationMessages.RegistrationMessage = PrismData.PushNotification.registrationMessage;
            PushNotificationMessages.RegistrationMessageDescription = PrismData.PushNotification.registrationMessageDescription;
            PushNotificationMessages.UnregistrationMessage = PrismData.PushNotification.unregistrationMessage;
            PushNotificationMessages.UnregistrationMessageDescription = PrismData.PushNotification.unregistrationMessageDescription;
            PushNotificationMessages.ReceivedMessage = PrismData.PushNotification.receivedMessage;
            PushNotificationMessages.IsShowRegistrationMessage = true; // show RegistrationMessage on task bar.

            CrossAzurePushNotification.Current.RegisterForAzurePushNotification();
        }

    }
}
