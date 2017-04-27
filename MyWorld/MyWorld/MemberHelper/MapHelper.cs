using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyWorld.MemberHelper
{
   public class MapHelper
    {
        Geocoder geoCoder;
        public MapHelper()
        {
            geoCoder = new Geocoder();
        }
       async public Task<string> getCordinateFromAddress(string _address)
        {
            string addressss = null;
            try
            {
                // Task<string> address=null;

                var approximateLocations = await geoCoder.GetPositionsForAddressAsync(_address);
              //  addressss = approximateLocations.FirstOrDefault().Latitude + "," + approximateLocations.FirstOrDefault().Longitude;


                foreach (var position in approximateLocations)
                {
                
                       addressss += position.Latitude + ", " + position.Longitude + "\n";
                }
               
                return addressss;
            }
            catch { return addressss; }
        }

        async public Task<string> getAddressFromCordinate(double _latitude,double _longitude)
        {
            string MemberAddress = null,add=null;
            try
            {

                var position = new Position(_latitude, _longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                MemberAddress = possibleAddresses.FirstOrDefault();
                string[] address1 = MemberAddress.Split(',');
                for (int i = 0; i < address1.Length; i++)
                {
                    add = address1[0];
                    if (i==1)
                        add += address1[i] + " ";
                    if (i == 2)
                    {
                        add += address1[i] + " ";
                        break;
                    }
                }
             

                return add;
            }
            catch { return MemberAddress; }
        }

         public void navigateToAddressFromCurrent(string _address)
        {
            var address = _address;
            try
            {
                switch (Device.OS)
                {
                    case TargetPlatform.iOS:
                        Device.OpenUri(
                          new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                        break;
                    case TargetPlatform.Android:
                        Device.OpenUri(
                          new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                        break;
                    case TargetPlatform.Windows:
                    case TargetPlatform.WinPhone:
                        Device.OpenUri(
                          new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                        break;
                }
            }
            catch { }

        }


        }
}
