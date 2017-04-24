using MyWorld.DTO;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public partial class MemberListPage : ContentPage
    {
        List<Member> lstMember;
        public MemberListPage()
        {try { 
            InitializeComponent();

            this.Title = "All Members";
            SearchBar.IsVisible = false;

                // toolBatStack.IsVisible = false;
                //  lstViewAllMEmber.ItemsSource =  App.Database.GetAllMember();

                //AddToolbarItem.Clicked += async (sender, e) => { await Navigation.PushAsync(new MemberPage() { BindingContext = new Member() }); };

                //ToolbarItems.Add(AddToolbarItem);
                CrossVibrate.Current.Vibration(500);
            }
            catch { }

        }
        async public void SearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = SearchBar.Text;
                lstMember = await App.Database.GetAllMember();
                if (!string.IsNullOrEmpty(keyword))
                    lstViewAllMEmber.ItemsSource = lstMember.Where(n => n.FirstName.ToLower().Contains(keyword.ToLower()));
                else
                {
                    SearchBar.IsVisible = false;
                    searchbar_icon.Icon = "Search_Android.png";
                    lstViewAllMEmber.ItemsSource = lstMember;
                    lstViewAllMEmber.Focus();
                }
            }
            catch { }
        }
        public void OnToolbar_Cliked(object sender, EventArgs e)
        {
            try
            {
                SearchBar.IsVisible = true;
                SearchBar.Focus();
                searchbar_icon.Icon = "";
                searchbar_icon.Text = "";
            }
            catch { }
        }
        public async void OnAdd_Cliked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new MemberPage() { BindingContext = new Member() });
                //lstName.Add("test");
                //SearchBar.IsVisible = true;
                //SearchBar.Focus();
                //searchbar_icon.Icon = "";
                //searchbar_icon.Text = "";
            }
            catch { }
        }
        public async void OnRef_Cliked(object sender, EventArgs e)
        {
            try
            {
                lstViewAllMEmber.ItemsSource = await App.Database.GetAllMember();
            }
            catch { }
        }
        public void OnItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {try
            {
                Member member;
                if (e.SelectedItem != null)
                {
                    member = new DTO.Member();
                    member = e.SelectedItem as Member;
                    //DisplayAlert("Notification", "You Select " + name, "No", "Yes");
                    Navigation.PushAsync(new ShowMember(member));

                }
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
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                lstViewAllMEmber.ItemsSource = await App.Database.GetAllMember();
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
    }
}
