using MyWorld.MemberHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyWorld.Screens.Mapp
{
    public class MemberMapRoute : ContentPage
    {
        string address = null;
        MapHelper mapHelper;
        public MemberMapRoute(string _address="Noida")
        {
            address = _address;
            mapHelper = new MemberHelper.MapHelper();
        }

        protected override void OnAppearing()
        {  try
            {
                mapHelper.navigateToAddressFromCurrent(address);
            }
            catch
            { }
        }

        protected override void OnDisappearing()
        {
            try
            {
               
                base.OnDisappearing();

                Navigation.PopAsync();
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
