using MyWorld.MemberHelper;
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
    public class DeafultMap : ContentPage
    {
        Geocoder geoCoder;
        Entry txtSource, txtDestination;
        StackLayout stack;
        Button btnMap;
        public DeafultMap()
        {
            this.Title = "Default";
            geoCoder = new Geocoder();
            txtSource = new Entry();
            txtSource.HeightRequest = 40;
            txtDestination = new Entry();
            txtDestination.HeightRequest = 40;

            
            btnMap = new Button();
            btnMap.Clicked += BtnMap_Clicked;
            btnMap.Text = "Map";

        }

        private void BtnMap_Clicked(object sender, EventArgs e)
        {
            
        }

        async protected override void OnAppearing()
        {
           try
          {
               // base.OnAppearing();
                txtSource.TextChanged += TxtCell_TextChanged;

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                locator.AllowsBackgroundUpdates = true;
                locator.AllowsBackgroundUpdates = true;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 60000);
                Double Latitude = position.Latitude;
                Double Longitude = position.Longitude;
                if (string.IsNullOrEmpty(txtSource.Text))
                {
                    txtSource.Text = await (new MapHelper().getAddressFromCordinate(Latitude, Longitude));
                }
                if (string.IsNullOrEmpty(txtDestination.Text))
                {
                    txtSource.Text = await (new MapHelper().getAddressFromCordinate(Latitude, Longitude));
                }

                stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(txtSource);
                stack.Children.Add(btnMap);
                
                stack.Children.Add(await getMap(Latitude, Longitude));
                        Content = stack;
            }
            catch (Exception ex) { }
        }
       async public Task<Map> getMap(double _latitude,double _longitude)
        {

            Map map = new Map(
               MapSpan.FromCenterAndRadius(
                       new Position(_latitude, _longitude), Distance.FromMiles(.5)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasScrollEnabled = true,
                HasZoomEnabled = true,
                MapType = MapType.Street


            };
            var possition1 = new Position(_latitude, _longitude);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = possition1,
                Label =Convert.ToString( new MapHelper().getAddressFromCordinate(_latitude, _longitude)),
                Address = "X=" + _latitude + ",y=" + _longitude,

            };
            map.Pins.Add(pin1);
            return map;
        }

        private void TxtCell_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDestination.Text.Contains(" "))
            { 
            string cordinate = Convert.ToString(new MapHelper().getCordinateFromAddress(txtDestination.Text));
            string[] address = cordinate.Split(',');
            Double latitude = Convert.ToDouble(address[0]);
            Double longitude = Convert.ToDouble(address[1]);
        }
            


        }
    }
}
