using AzurePushNotification.Plugin;
using AzurePushNotification.Plugin.Abstractions;
using MyWorld.MemberHelper;
using MyWorld.Screens;
using MyWorld.Screens.Mapp;
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
                Title = "myWORLD",
            };
            // MainPage = new NavigationPage(new MemberMap());

            MainPage = new NavigationPage(new MasterDetailMenuPage())
            {
                BarBackgroundColor = Color.Green,//Color.FromHex("#ff5300"),
                BarTextColor = Color.FromHex("#8F8F85"),// Color.White,
                Icon = "myworld2.jpg",
            };

            
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
