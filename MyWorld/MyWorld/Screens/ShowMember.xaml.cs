using MyWorld.DTO;
using MyWorld.MemberHelper;
using Plugin.TextToSpeech;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public partial class ShowMember : ContentPage
    {
        public MemberComm memberComm;
        public Member member;
        public ShowMember(Member member)
        {try { 
            member.FirstName = member.FirstName.ToUpper();
            BindingContext = member;
            InitializeComponent();
            CrossTextToSpeech.Current.Speak("Helloooo " + member.FirstName);
            memberComm = new MemberHelper.MemberComm();


            var tapCallImage = new TapGestureRecognizer();
            tapCallImage.Tapped += tapMemberImage_Tapped;
            imageCall.GestureRecognizers.Add(tapCallImage);


            var taEmailImage = new TapGestureRecognizer();
            taEmailImage.Tapped += tapMemberEmailImage_Tapped;
            imageGmail.GestureRecognizers.Add(taEmailImage);
                CrossVibrate.Current.Vibration(500);
            }
            catch { }
        }

        void tapMemberEmailImage_Tapped(object sender, EventArgs e)
        {try { 
            member = BindingContext as Member;
            Navigation.PushAsync(new MemberEmail(member));
            }
            catch { }
        }
        void tapMemberImage_Tapped(object sender, EventArgs e)
        {try { 
            member = BindingContext as Member;
            memberComm.callMember( member.FirstName + " " + member.LastName, member.PhoneNumber);
            }
            catch { }
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
            }
            catch { }
        }
        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();

            }
            catch { }
        }
    }
}
