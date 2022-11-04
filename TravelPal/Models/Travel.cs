using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {

        public int travellers { get; set; }
        public string destination { get; set; }
        public Countries country { get; set; }


        //public int travelDays { get; set; }
        //public List<PackingListItem> packingList { get; set; }
        //public DateTime startDate { get; set; }
        //public DateTime endDate { get; set; }


        public Travel(string destination, int travellers, Countries country)
        {
            this.destination = destination;
            this.travellers = travellers;
            this.country = country;
        }

        public virtual string GetInfo()
        {
            return $"Destination: {destination} | Number Of Travellers: {travellers} ";
        }
    }
}
