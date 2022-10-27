using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class User : IUser
    {
        public List<Travel> travels { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
