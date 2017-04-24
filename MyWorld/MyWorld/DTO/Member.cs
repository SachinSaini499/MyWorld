using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.DTO
{
   public class Member
    {
        [PrimaryKey,AutoIncrement]
        public  Int32 Id { get; set; }
        public  string FirstName { set; get; }
        public  string LastName { set; get; }
        public string Age { set; get; }
        public string Status { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string DOB { set; get; }
        public string Address { set; get; }
        public string Image { set; get; }
    }
}
