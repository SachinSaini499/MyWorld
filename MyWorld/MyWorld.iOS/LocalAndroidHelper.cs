using System;
using System.Collections.Generic;
using System.Text;
using MyWorld.iOS;
using MyWorld.MemberHelper;

namespace MyWorld.iOS
{
    class LocalAndroidHelper :IMemberHelper
    {
         public string GetLocalFileNamePath(string fileName)
        { 
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        
        }
    
    }
}
