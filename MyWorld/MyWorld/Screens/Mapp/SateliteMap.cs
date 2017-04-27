using MyWorld.MemberHelper;
using Plugin.ExternalMaps;
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
    //public class SateliteMap : ContentPage
    //{
    //    public SateliteMap()
    //    {
    //        this.Title = "Satelite";
    //    }
    //    async protected override void OnAppearing()
    //    {
    //        try
    //        {
    //            base.OnAppearing();
    //            var locator = CrossGeolocator.Current;
    //            locator.DesiredAccuracy = 50;
    //            var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
    //            Double Latitude = position.Latitude;
    //            Double Longitude = position.Longitude;

    //            var map = new Map(
    //               MapSpan.FromCenterAndRadius(
    //                       new Position(Latitude, Longitude), Distance.FromMiles(.5)))
    //            {
    //                IsShowingUser = true,
    //                VerticalOptions = LayoutOptions.FillAndExpand,
    //                HasScrollEnabled = true,
    //                HasZoomEnabled = true,
    //                MapType=MapType.Satellite


    //            };
    //            var possition1 = new Position(Latitude, Longitude);

    //            var pin1 = new Pin
    //            {
    //                Type = PinType.Place,
    //                Position = possition1,
    //                Label = "Your Location",
    //                Address = "X,y"

    //            };
    //            map.Pins.Add(pin1);
    //            var stack = new StackLayout { Spacing = 0 };
    //            stack.Children.Add(map);
    //            Content = stack;
    //        }
    //        catch (Exception ex) { }
    //    }
    //}
    public class SateliteMap : ContentPage
    {
        Entry entrySource = new Entry();
        Entry entryDestination = new Entry();
        Button btnMap = new Button();
        StackLayout stack;
        Map map;
        public SateliteMap()
        {
            this.Title = "Satelite";
            btnMap.Text = "Get Route";
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


                entrySource.Text = await new MapHelper().getAddressFromCordinate(Latitude, Longitude);
                //entryDestination.Text = await new MapHelper().getAddressFromCordinate(Latitude, Longitude);
                getMap(Latitude, Longitude, entrySource.Text);
                stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(entrySource);
                //  stack.Children.Add(entryDestination);
                stack.Children.Add(btnMap);
                stack.Children.Add(map);
                Content = stack;


                btnMap.Clicked += BtnMap_Clicked;
            }
            catch (Exception ex) { }
        }

        async private void BtnMap_Clicked(object sender, EventArgs e)
        {
            try
            {
                string source = entrySource.Text;
                var success = await CrossExternalMaps.Current.NavigateTo("", source, "", "", "", "India", "In");

                //string destination = entryDestination.Text;
                //string sourceCordinate =await new MapHelper().getCordinateFromAddress(source);
                //string[] address1 = sourceCordinate.Split(',');
                //       Double latitude = Convert.ToDouble(address1[0]);
                //      Double longitude = Convert.ToDouble(address1[1]);

                //string destinationCordinate = await new MapHelper().getCordinateFromAddress(destination+ "Hospitals");
                //string[] address = destinationCordinate.Split(',');
                //Double destinationLatitude = Convert.ToDouble(address[0]);
                //Double destinationLongitude = Convert.ToDouble(address[1]);
                //getMap(latitude, longitude, destinationLatitude, destinationLongitude);
                ////Get source cordinate(sourcelatitude, sourcelongitude) from text 
                ////Get destination cordinate(destinationlatitude ,destinationlongitude) from text 
                ////Call GetMap
                //stack = new StackLayout { Spacing = 0 };
                //stack.Children.Add(entrySource);
                //stack.Children.Add(entryDestination);
                //stack.Children.Add(btnMap);
                //stack.Children.Add(map);
                //Content = stack;
            }
            catch { }
        }

        void getMap(double _sourceLatitude, double _sourceLongitude,string address)
        {


            map = new Map(
              MapSpan.FromCenterAndRadius(
                      new Position(_sourceLatitude, _sourceLongitude), Distance.FromMiles(.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasScrollEnabled = true,
                HasZoomEnabled = true,
                MapType = MapType.Satellite


            };
            var possition1 = new Position(_sourceLatitude, _sourceLongitude);
            //  var possition2 = new Position(_destinationLatitude, _destinationLongitude);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = possition1,
                Label = address,
                Address = "X=" + _sourceLatitude + ",y=" + _sourceLongitude,

            };
            //var pin2 = new Pin
            //{
            //    Type = PinType.Place,
            //    Position = possition2,
            //    Label = "Your Location",
            //    Address = "X=" + _destinationLatitude + ",y=" + _destinationLongitude,

            //};
            map.Pins.Add(pin1);
            // map.Pins.Add(pin2);
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
