using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public partial class Home : ContentPage
    {
        public Home()
        {try
            {
                InitializeComponent();

                var tapMamberImage = new TapGestureRecognizer();
                tapMamberImage.Tapped += tapMemberImage_Tapped;
                ImgMember.GestureRecognizers.Add(tapMamberImage);

                var tapAllMamberImage = new TapGestureRecognizer();
                tapAllMamberImage.Tapped += tapAllMemberImage_Tapped;
                ImgAllMember.GestureRecognizers.Add(tapAllMamberImage);

                var tapScannersImage = new TapGestureRecognizer();
                tapScannersImage.Tapped += tapScannersImage_Tapped;
                ImgScanners.GestureRecognizers.Add(tapScannersImage);

                CrossVibrate.Current.Vibration(500);
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

        async void tapScannersImage_Tapped(object sender, EventArgs e)
        {
            try
            {
                // new NavigationPage(new MemberPage());
                await Navigation.PushAsync(new Scaners());
            }
            catch { }
        }
        async void tapMemberImage_Tapped(object sender, EventArgs e)
        {try
            {
                // new NavigationPage(new MemberPage());
                await Navigation.PushAsync(new MemberPage());
            }
            catch { }
        }
        async void tapHomeImage_Tapped(object sender, EventArgs e)
        {try { 
            await Navigation.PushAsync(new Home());
            }
            catch { }
        }

        async void tapAllMemberImage_Tapped(object sender, EventArgs e)
        {try { 
            await Navigation.PushAsync(new MemberListPage());
            }
            catch { }
        }
    }
}
