using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyWorld.Screens
{
    public partial class GPSPage : ContentPage
    {
        public GPSPage()
        {
            InitializeComponent();
            var map = new Map(
           MapSpan.FromCenterAndRadius(
                   new Position(37, -122), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }

    }
}
     //async   protected override void OnAppearing()
     //   {
     //       try
     //       {
     //           base.OnAppearing();
     //           var locator = CrossGeolocator.Current;
     //           locator.DesiredAccuracy = 50;
     //           var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
     //           Double Latitude = position.Latitude;
     //           Double Longitude = position.Longitude;
     //           //var map = new Map(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromMiles(.5))) { IsShowingUser = true, VerticalOptions = LayoutOptions.FillAndExpand };

     //           var possition1 = new Position(Latitude, Longitude);
     //           var pin1 = new Pin
     //           {
     //               Type = PinType.Place,
     //               Position = possition1,
     //           };

     //           memberMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromMiles(.5)));
     //           memberMap.HasScrollEnabled = true;
     //           memberMap.HasZoomEnabled = true;
     //           memberMap.IsShowingUser = true;
     //           memberMap.Pins.Add(pin1);
     //       }
     //       catch (Exception ex) { }
     //   }

     //async   private void btnMap_Clicked(object sender, EventArgs e)
        
            //try
            //{
            //    base.OnAppearing();
            //    var locator = CrossGeolocator.Current;
            //    locator.DesiredAccuracy = 50;
            //    var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
            //    Double Latitude = position.Latitude;
            //    Double Longitude = position.Longitude;
            //    //var map = new Map(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromMiles(.5))) { IsShowingUser = true, VerticalOptions = LayoutOptions.FillAndExpand };

            //    var possition1 = new Position(Latitude, Longitude);
            //    var pin1 = new Pin
            //    {
            //        Type = PinType.Place,
            //        Position = possition1,
            //    };

            //    memberMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Latitude, Longitude), Distance.FromMiles(.5)));
            //    memberMap.HasScrollEnabled = true;
            //    memberMap.HasZoomEnabled = true;
            //    memberMap.IsShowingUser = true;
            //    memberMap.Pins.Add(pin1);
            //}
            //catch (Exception ex) { }
//
        //}
    

