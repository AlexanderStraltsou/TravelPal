using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Trip : Travel
    {

        public TripTypes Type { get; set; }

        public Trip(string destination, int travellers, Countries country, TripTypes tripType) : base(destination, travellers, country)
        {
            Type = tripType;
        }


        //Send short info to the listView
        public override string GetInfo()
        {
            return $"{base.destination} / {base.travellers} / {base.country}";
        }
    }
}
