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
    }
}
