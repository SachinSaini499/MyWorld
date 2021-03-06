﻿using MyWorld.DTO;
using MyWorld.Screens.Mapp;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public partial class MasterDetailMenuPage : MasterDetailPage
    {
        public MasterDetailMenuPage()
        {try
            {
                InitializeComponent();
                Detail = new NavigationPage(new Home());
                IsPresented = false;
                var lstMasterPageItem = new List<MasterPageItem>();
                lstMasterPageItem.Add(new DTO.MasterPageItem { Title = "Home", ImageSource = "myworld33.jpg", TargetType = typeof(Home) });
                lstMasterPageItem.Add(new DTO.MasterPageItem { Title = "Member", ImageSource = "addmemberr.jpg", TargetType = typeof(MemberPage) });
                lstMasterPageItem.Add(new DTO.MasterPageItem { Title = "All Member", ImageSource = "allmemberr2.jpg", TargetType = typeof(MemberListPage) });
                lstMasterPageItem.Add(new DTO.MasterPageItem { Title = "Scanners", ImageSource = "FSIcon3.jpg", TargetType = typeof(Scaners) });
                lstMasterPageItem.Add(new DTO.MasterPageItem { Title = "Map", ImageSource = "route2.png", TargetType = typeof(MemberMap) });

                listView.ItemsSource = lstMasterPageItem;
                listView.ItemSelected += ListView_ItemSelected;
                NavigationPage.SetHasNavigationBar(this, false);
      
                
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
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {try
            {
                var item = e.SelectedItem as MasterPageItem;
                if (item != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    //listView.ItemsSource = null;
                    IsPresented = false;
                }
            }
            catch { }         
        }      

        //public void Home_Clicked(object sender, EventArgs e)
        //{
        //    Detail = new NavigationPage(new Home());
        //    IsPresented = false;
        //}
        //public void Member_Clicked(object sender,EventArgs e)
        //{
        //    Detail = new NavigationPage(new MemberPage());
        //    IsPresented = false;
        //}

        //public void AllMember_Clicked(object sender, EventArgs e)
        //{
        //    Detail = new NavigationPage(new MemberListPage());
        //    IsPresented = false;
        //}
    }
}
