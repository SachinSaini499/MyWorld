using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using System.Runtime.CompilerServices;
using MyWorld.Droid;
using MyWorld.MemberHelper;

[assembly: Xamarin.Forms.Dependency (typeof (MyWorld.Droid.LocalAndroidHelper))]
namespace MyWorld.Droid
{
    class LocalAndroidHelper: IMemberHelper
    {
        public string GetLocalFileNamePath(string fileName)
        {
            var path = Path.Combine((Environment.GetFolderPath(Environment.SpecialFolder.Personal)));
           // string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
          //  string folderPath = Path.Combine(path, "Database");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return Path.Combine(path, fileName);
        }

        public string GetPhotoLocPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string folderPath = Path.Combine(path, "Picture");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
        
    }
}