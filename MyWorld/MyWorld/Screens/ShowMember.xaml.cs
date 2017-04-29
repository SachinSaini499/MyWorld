using MyWorld.DTO;
using MyWorld.MemberHelper;
using MyWorld.Screens.Mapp;
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


                var tapRouteImage = new TapGestureRecognizer();
                tapRouteImage.Tapped += tapRouteImage_Tapped;
                imageNavigate.GestureRecognizers.Add(tapRouteImage);
                
                CrossVibrate.Current.Vibration(200);

            }
            catch { }
        }

        void tapRouteImage_Tapped(object sender, EventArgs e)
        {
            try
            {
                member = BindingContext as Member;
                Navigation.PushAsync(new MemberMapRoute(member.Address));
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
        protected override bool OnBackButtonPressed()
        {
            try
            {
                //   DisplayAlert("Notification", "You want to exit ?", "No", "Yes");
                return base.OnBackButtonPressed();
            }
            catch { return base.OnBackButtonPressed(); }

        }
    }
}
