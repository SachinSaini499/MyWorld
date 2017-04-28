using MyWorld.DTO;
using MyWorld.MemberHelper;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.TextToSpeech;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
   
    public partial class MemberPage : ContentPage
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        public string wrongeData;
        Member member;
        MemberComm memberOTP;
        public MemberPage()
        {try { 
            InitializeComponent();
            this.Title = "Add Member";
            BindingContext = new Member();
            MainImage.Source = "DumyImage.jpg";
            memberOTP = new MemberHelper.MemberComm();

            
             var tapMamberImage = new TapGestureRecognizer();
            tapMamberImage.Tapped += tapMemberImage_Tapped;
            btnImagePicMembr.GestureRecognizers.Add(tapMamberImage);

            var tapbtnPicBrows = new TapGestureRecognizer();
            tapbtnPicBrows.Tapped += tapbtnPicBrows_Tapped;
            btnPicBrows.GestureRecognizers.Add(tapbtnPicBrows);
                CrossVibrate.Current.Vibration(500);
                // btnAddMembr.IsEnabled = false;
            }
            catch { }
        }
        //private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        //{
        //    //lblDate.Text =Convert.ToString(e.NewDate);
        //}

        //public void email_TextChanged(object sender, TextChangedEventArgs e)
        // {
        //     if (Invalid)
        //     {
        //         entryField.TextChanged -= Entry1 _TextChanged;
        //         entryField.Text = e.OldTextValue;
        //         entryField.TextChanged += Entry1 _TextChanged;
        //     }
        // }

        async void tapbtnPicBrows_Tapped(object sender, EventArgs e)
        {try { 
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("OOps", ":( pic photo not supported.", "OK");
                return;
            }
            string pathpic = App.getPicturePath;
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            // await DisplayAlert("File Location", file.Path, "OK");

            entryImage.Text = file.Path;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

                //or:
                //image.Source = ImageSource.FromFile(file.Path);
                //image.Dispose();
            }
            catch { }

        }
        async void tapMemberImage_Tapped(object sender, EventArgs e)
        {try { 
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            string pathpic = App.getPicturePath;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "@" + pathpic,
                Name = "pic.jpg",
                AllowCropping = true

            });

            if (file == null)
                return;

            // await DisplayAlert("File Location", file.Path, "OK");

            entryImage.Text = file.Path;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

                //or:
                //image.Source = ImageSource.FromFile(file.Path);
                //image.Dispose();
            }
            catch { }
        }
        async void AddButtonClicked(object sender, EventArgs e)
        {
            try { 
            string email, firstName, phoneNumber;
            email = entryEmail.Text; firstName = entryFirstName.Text; phoneNumber = entryPhoneNumber.Text;
            bool IsEmailValid = false; bool IsNameValid = false; bool IsPhoneNumberValid = false; bool IsOTPValid = false;
            member = new DTO.Member();
            member = (Member)BindingContext;

            if (btnAddMembr.Text.ToLower().Contains("otp"))
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    if (phoneNumber.Length == 10)
                    {
                        IsPhoneNumberValid = true;
                    }
                }
                if (!IsPhoneNumberValid)
                {
                    PhoneNumberValImage.IsVisible = true;
                    PhoneNumberValImage.Focus();
                    wrongeData = "Phone Number";
                    CrossTextToSpeech.Current.Speak(PrismData.speechMessage + wrongeData);
                }
                else
                {
                    if (memberOTP.sendSMS(phoneNumber))
                    {
                        entryOTP.IsVisible = true;
                        btnAddMembr.Text = " Add ";
                        entryPhoneNumber.IsEnabled = false;
                        PhoneNumberValImage.IsVisible = false;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(email))
                {
                    IsEmailValid = (Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    firstName = firstName.ToUpper();
                    IsNameValid = true;
                }
                if (!string.IsNullOrEmpty(entryOTP.Text))
                {
                    if (memberOTP.verifyOTP(entryOTP.Text))
                    {
                        IsOTPValid = true;
                    }
                }
                if (IsEmailValid && IsNameValid && IsOTPValid)
                {

                    if (string.IsNullOrEmpty(member.Address))
                    {
                        member.Address = PrismData.notAvail;
                    }
                    if (string.IsNullOrEmpty(member.Age))
                    {
                        member.Age = PrismData.notAvail;
                    }
                    if (string.IsNullOrEmpty(member.DOB))
                    {
                        member.DOB = PrismData.notAvail;
                    }
                    if (string.IsNullOrEmpty(member.Image))
                    {
                        member.Image = "DumyImage.jpg";
                    }
                    if (string.IsNullOrEmpty(member.LastName))
                    {
                        member.LastName = PrismData.notAvail;
                    }
                    if (pickerBehavior.SelectedIndex == -1)
                    {
                        member.Status = PrismData.notAvail;
                    }
                    else { member.Status = pickerBehavior.Items[pickerBehavior.SelectedIndex]; }
                    await App.Database.SaveMember(member);
                    await Navigation.PopAsync();
                }
                else
                {
                    if (!IsEmailValid)
                    {
                        EmailValImage.IsVisible = true;
                        wrongeData = "Email";
                        //  EmailValImage.Focus();
                    }
                    if (!IsNameValid)
                    {
                        FNameValImage.IsVisible = true;
                        FNameValImage.Focus();
                        wrongeData = wrongeData + "first name";
                    }
                    if (!IsOTPValid)
                    {
                        FNameValImage.IsVisible = true;                      
                        wrongeData = wrongeData + "and O T P";
                    }
                    CrossTextToSpeech.Current.Speak(PrismData.speechMessage + wrongeData);
                }
            }
            }
            catch { }

        }
        async void PhotoButtonClicked(object sender, EventArgs e)
        {try { 
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            string pathpic = App.getPicturePath;
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "@" + pathpic,
                Name = "pic.jpg",
                AllowCropping = true

            });

            if (file == null)
                return;

            // await DisplayAlert("File Location", file.Path, "OK");

            entryImage.Text = file.Path;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

                //or:
                //image.Source = ImageSource.FromFile(file.Path);
                //image.Dispose();
            }
            catch { }
        }
        async void BrowseButtonClicked(object sender, EventArgs e)
        {try { 
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("OOps", ":( pic photo not supported.", "OK");
                return;
            }
            string pathpic = App.getPicturePath;
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            // await DisplayAlert("File Location", file.Path, "OK");

            entryImage.Text = file.Path;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

                //or:
                //image.Source = ImageSource.FromFile(file.Path);
                //image.Dispose();
            }
            catch { }
        }
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            try { 

            entryDate.Text = Convert.ToString(e.NewDate);
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
    }
}
