using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new()

        {
            new Travel()
            {
                destination = "Montreal",
                travellers = 2
            },

            new Travel()
            {
                destination = "Rome",
                travellers = 4
            },

            new Travel()
            {
                destination = "Miami",
                travellers = 1
            }

        };

        public void AddTravel(string destination, int travellers)
        {

        }


    }
}
