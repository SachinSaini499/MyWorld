using MyWorld.MemberHelper;
using MyWorld.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyWorld
{
    public class App : Application
    {
        static MemberDatabase memberDatabase;
        static string picturePath;

        public App()
        {           
            var content = new ContentPage
            {
                Title = "MyWorld",                           
            };
            MainPage = new NavigationPage(new GPSPage());

            //MainPage = new NavigationPage(new MasterDetailMenuPage())
            //{
            //    BarBackgroundColor = Color.Green,//Color.FromHex("#ff5300"),
            //    BarTextColor = Color.White,

            //};
        }
        public static MemberDatabase Database
        {
            get
            {
                if (memberDatabase == null)
                {
                    memberDatabase = new MemberDatabase(DependencyService.Get<IMemberHelper>().GetLocalFileNamePath("Member.db3"));
                }
                return memberDatabase;
            }
        }
        public static string getPicturePath
        {
            get
            {
                if (String.IsNullOrEmpty(picturePath))
                {
                    picturePath = DependencyService.Get<IMemberHelper>().GetPhotoLocPath();
                }
                return picturePath;
            }

        }
        public static MemberDatabase Picture
        {
            get
            {
                if (memberDatabase == null)
                {
                    memberDatabase = new MemberDatabase(DependencyService.Get<IMemberHelper>().GetLocalFileNamePath("Member.db3"));
                }
                return memberDatabase;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
