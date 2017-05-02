using MyWorld.MemberHelper;
using Plugin.ExternalMaps;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyWorld.Screens.Mapp
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public class DeafultMap : ContentPage
    {
        Entry entrySource = new Entry();
        Entry entryDestination = new Entry();
        Button btnMap = new Button();
        StackLayout stack;
        Map map;
        public DeafultMap()
        {
            this.Title = "Default";
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
                

                entrySource.Text =await new MapHelper().getAddressFromCordinate(Latitude, Longitude);
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

      async  private void BtnMap_Clicked(object sender, EventArgs e)
        {try
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
        void getMap(double _sourceLatitude, double _sourceLongitude,string _yourLocation)
        {


            map = new Map(
              MapSpan.FromCenterAndRadius(
                      new Position(_sourceLatitude, _sourceLongitude), Distance.FromMiles(.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasScrollEnabled = true,
                HasZoomEnabled = true,
                MapType = MapType.Street


            };
            var possition1 = new Position(_sourceLatitude, _sourceLongitude);
          //  var possition2 = new Position(_destinationLatitude, _destinationLongitude);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = possition1,
                Label = _yourLocation,
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

    }

    //public class DeafultMap : ContentPage
    //{
    //    Geocoder geoCoder;
    //    Entry txtSource, txtDestination;
    //    StackLayout stack;
    //    Button btnMap;
    //    public DeafultMap()
    //    {
    //        this.Title = "Default";
    //        geoCoder = new Geocoder();
    //        txtSource = new Entry();
    //        txtSource.HeightRequest = 40;
    //        txtDestination = new Entry();
    //        txtDestination.HeightRequest = 40;


    //        btnMap = new Button();
    //        btnMap.Clicked += BtnMap_Clicked;
    //        btnMap.Text = "Map";

    //    }

    //    private void BtnMap_Clicked(object sender, EventArgs e)
    //    {

    //    }

    //    async protected override void OnAppearing()
    //    {
    //       try
    //      {
    //           // base.OnAppearing();
    //            txtSource.TextChanged += TxtCell_TextChanged;

    //            var locator = CrossGeolocator.Current;
    //            locator.DesiredAccuracy = 50;
    //            locator.AllowsBackgroundUpdates = true;
    //            locator.AllowsBackgroundUpdates = true;
    //            var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
    //            Double Latitude = position.Latitude;
    //            Double Longitude = position.Longitude;
    //            if (string.IsNullOrEmpty(txtSource.Text))
    //            {
    //                txtSource.Text = await (new MapHelper().getAddressFromCordinate(Latitude, Longitude));
    //            }
    //            if (string.IsNullOrEmpty(txtDestination.Text))
    //            {
    //                txtSource.Text = await (new MapHelper().getAddressFromCordinate(Latitude, Longitude));
    //            }

    //            stack = new StackLayout { Spacing = 0 };
    //            stack.Children.Add(txtSource);
    //            stack.Children.Add(btnMap);

    //            stack.Children.Add(await getMap(Latitude, Longitude));
    //                    Content = stack;
    //        }
    //        catch (Exception ex) { }
    //    }
    //   async public Task<Map> getMap(double _latitude,double _longitude)
    //    {

    //        Map map = new Map(
    //           MapSpan.FromCenterAndRadius(
    //                   new Position(_latitude, _longitude), Distance.FromMiles(.5)))
    //        {
    //            IsShowingUser = true,
    //            VerticalOptions = LayoutOptions.FillAndExpand,
    //            HasScrollEnabled = true,
    //            HasZoomEnabled = true,
    //            MapType = MapType.Street


    //        };
    //        var possition1 = new Position(_latitude, _longitude);

    //        var pin1 = new Pin
    //        {
    //            Type = PinType.Place,
    //            Position = possition1,
    //            Label =Convert.ToString( new MapHelper().getAddressFromCordinate(_latitude, _longitude)),
    //            Address = "X=" + _latitude + ",y=" + _longitude,

    //        };
    //        map.Pins.Add(pin1);
    //        return map;
    //    }

    //    private void TxtCell_TextChanged(object sender, TextChangedEventArgs e)
    //    {
    //        if (txtDestination.Text.Contains(" "))
    //        { 
    //        string cordinate = Convert.ToString(new MapHelper().getCordinateFromAddress(txtDestination.Text));
    //        string[] address = cordinate.Split(',');
    //        Double latitude = Convert.ToDouble(address[0]);
    //        Double longitude = Convert.ToDouble(address[1]);
    //    }



    //    }
    //}
}
