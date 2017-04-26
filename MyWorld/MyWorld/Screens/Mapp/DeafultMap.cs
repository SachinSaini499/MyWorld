using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyWorld.Screens.Mapp
{
    public class DeafultMap : ContentPage
    {
        public DeafultMap()
        {
            this.Title = "Default";
        }
        async protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
                Double Latitude = position.Latitude;
                Double Longitude = position.Longitude;
                
                var map = new Map(
                   MapSpan.FromCenterAndRadius(
                           new Position(Latitude, Longitude), Distance.FromMiles(.5)))
                {
                    IsShowingUser = true,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HasScrollEnabled = true,
                    HasZoomEnabled = true,
                    MapType=MapType.Street


                };
                var possition1 = new Position(Latitude, Longitude);

                var pin1 = new Pin
                {
                    Type = PinType.Place,
                    Position = possition1,
                    Label = "Your Location",
                    Address = "X="+ Latitude+",y="+Longitude,

                };
                map.Pins.Add(pin1);
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);
                Content = stack;
            }
            catch (Exception ex) { }
        }
    }
}
