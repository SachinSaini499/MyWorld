using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.MemberHelper
{
    public class MemberComm
    {
        public bool sendSMS(string _phoneNumber = "+919999337329", string _msg = "Hello your otp is 1234")
        {
            bool flag = false;
            var smsMessanger = CrossMessaging.Current.SmsMessenger;
            if (smsMessanger.CanSendSmsInBackground)
            {
                //smsMessanger.SendSmsInBackground(_phoneNumber, "Hello your otp is "+1234);
                flag = true;
                return flag;
            }
            else if (smsMessanger.CanSendSms)
            {
                // smsMessanger.SendSms(_phoneNumber, "Hello your otp is " + 1234);
                flag = true;
                return flag;
            }
            return flag;

        }

        public bool callMember(string _name, string _phoneNumber = "+919999337329")
        {
            bool flag = false;
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                phoneDialer.MakePhoneCall(_phoneNumber, _name);
                flag = true;
                return flag;
            }
            return flag;

        }

        public bool sendEmail(string _To,string _cC,string _Sub,string _body)
        {
            bool flag = false;
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                //emailMessenger.SendEmail("to.plugins@xamarin.com", "Xamarin Messaging Plugin", "Well hello there from Xam.Messaging.Plugin");
                // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc. 
                var email = new EmailMessageBuilder()
                  .To(_To)
                  .Cc(_cC)                 
                  .Subject(_Sub)
                  .Body(_body)
                  .Build();
                
                //CrossMessaging.Current.Settings().Email.UseStrictMode = true;
                emailMessenger.SendEmail(email);
                flag = true;
                return flag;
            }
            return flag;

        }
        public bool verifyOTP(string _opt)
        {
            return true;

        }
    }
}
