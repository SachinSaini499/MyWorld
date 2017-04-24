using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.MemberHelper
{
   public interface IMemberHelper
    {
        string GetLocalFileNamePath(string filePath);

        string GetPhotoLocPath();
    }
}
