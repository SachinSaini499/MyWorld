using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.DTO
{
 public class PrismData
    {
        public static string notAvail = "Not Available";
        public static string speechMessage = "Please enter the valid ";
        public static  string sppechEmailInvalid = "";
        public static string sppechFirstNameInvalid = "";
        public static string sppechPhoneNumberInvalid = "";
        public static int maxSpeechChar = 1000;

        public class PushNotification
        {
            public static string receivedMessage = "A new message coming!";
            public static string registrationMessage = "Successfully registered to myWORLD!";
            public static string registrationMessageDescription = "Congratulation! You are member of myWORLD now.";
            public static string unregistrationMessage = "Successfully unregistered from myWORLD!";
            public static string unregistrationMessageDescription = "You Successfully unregistered from myWORLD!";

            public static string senderId = "56744142484";
            public static string azureNotificationName = "ucnotificationhub";
            public static string azureListenConnectionString = "Endpoint=sb://ucnotificationnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=v4cXZVrUV4wJttOu1no/NcVxStMkE0osor5Phg2qhUg=";
        }

    }
}
