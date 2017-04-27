using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyWorld.Screens.Mapp
{
    public class MemberMap : TabbedPage
    {
        public MemberMap()
        {
            try
            {
                this.Title = "Map";
                this.Children.Add(new DeafultMap());
                this.Children.Add(new SateliteMap());

            }
            catch(Exception ex) { }
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
