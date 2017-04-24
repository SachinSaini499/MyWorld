using CognitiveServices.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public class Scaners : TabbedPage
    {
        public Scaners()
        { try
            {
                this.Title = "Scaners";
                this.Children.Add(new ComputerVisionPage());
                this.Children.Add(new EmotionPage());
                this.Children.Add(new TextAnalyticsPage());
                this.Children.Add(new OcrPage());
            }
            catch { }
            }
        protected override bool OnBackButtonPressed()
        {
            try
            {
                //DisplayAlert("Notification", "You want to exit ?", "No", "Yes");

                return base.OnBackButtonPressed();
            }
            catch { return base.OnBackButtonPressed(); }

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
