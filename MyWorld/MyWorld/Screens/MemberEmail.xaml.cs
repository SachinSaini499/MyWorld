using Acr.SpeechRecognition;
//using Android.Database;
using MyWorld.DTO;
using MyWorld.MemberHelper;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWorld.Screens
{
    public partial class MemberEmail : ContentPage
    {
        public delegate ContentPage GetEditorInstance(string InitialEditorText);
        static public GetEditorInstance EditorFactory;
        static ISpeechToText speechRecognitionInstnace;
        Member member;
        MemberComm memberComm;
        string to, cc, sub, body;        
        IDisposable token;

        public void OnStart(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Start();
            // nameButtonStart.IsEnabled = false;
            //nameButtonStop.IsEnabled = true;
        }
        public void OnStop(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Stop();
            // nameButtonStart.IsEnabled = true;
            // nameButtonStop.IsEnabled = false;

        }
        //public void OnTextChange(object sender, EventArgsVoiceRecognition e)
        //{
        //    textLabeliOS.Text = e.Text;
        //    if (e.IsFinal)
        //    {
        //        nameButtonStart.IsEnabled = true;
        //    }
        //}
        public MemberEmail(Member member)
        {try { 
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "gmail.jpg");
            InitializeComponent();
            this.member = member;
            memberComm = new MemberHelper.MemberComm();
            editorTo.Text = member.Email;

            voiceButton.OnTextChanged += (s) => {
                editorBody.Text = s;
            };
            var tapSpeechImage = new TapGestureRecognizer();
            tapSpeechImage.Tapped += tapSpeechImage_Tapped;
            btnSpecchRecog.GestureRecognizers.Add(tapSpeechImage);
                CrossVibrate.Current.Vibration(500);
            }
            catch { }
        }

        public MemberEmail()
        {try { 
            var v = CrossVibrate.Current;
            v.Vibration(1000);
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetTitleIcon(this, "gmail.jpg");
            InitializeComponent();

                //this.member = member;
                //memberComm = new MemberHelper.MemberComm();
                //editorTo.Text = member.Email;  
            }
            catch { }
        }

        async void tapSpeechImage_Tapped(object sender, EventArgs e)
        {try { 
            var granted = await SpeechRecognizer.Instance.RequestPermission();
            if (granted)
            {
                token = SpeechRecognizer.Instance.Listen().Subscribe(x =>
                {
                    editorBody.Text = x.ToString();   // you will get each individual word the user speaks here
                });
                }
            }
            catch { }
        }

        async private void btnSend_Clicked(object sender, EventArgs e)
        {try { 
            // DisplayAlert("Warning", "hello are u sachin", "No","yes");           
            to = editorTo.Text;
            cc = editorCC.Text;
            sub = editorSub.Text;
            body = editorBody.Text;
            if (!string.IsNullOrEmpty(to))
            {if (!string.IsNullOrEmpty(sub))
                {
                    if (!string.IsNullOrEmpty(body))
                    {
                        
                        memberComm.sendEmail(editorTo.Text, editorCC.Text, editorSub.Text, editorBody.Text);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                      await  DisplayAlert("Warning", "Please enter message", "Ok");
                        return;

                    }
                }
                else
                {
                    await DisplayAlert("Warning", "Please enter subject", "Ok");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Warning","Please enter email id in To","Ok");
                return;
                }
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
        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();
            }
            catch { }
        }



        public void btnSpecchStop_Clicked(object sender, EventArgs e)
        {try { 
           // var token = SpeechRecognizer.Instance.Listen().Subscribe();            
            token.Dispose();
                //SpeechRecognizer.Instance.Listen().Subscribe(phrase => {  });  
            }
            catch { }
        }


    }
}
