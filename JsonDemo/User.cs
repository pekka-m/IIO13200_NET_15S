using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT
{
    public class User
    {
        private string Name;
        private string Gender;
        private string Birthday;

        public string name { get { return Name; } set { Name = value; } }
        public string gender { get { return Gender; } set { Gender = value; } }
        public string birthday { get { return Birthday; } set { Birthday = value; } }

        public User(string _name, string _gender, string _birthday)
        {
            this.Name = _name;
            this.Gender = _gender;
            this.Birthday = _birthday;
        }
    }
}
