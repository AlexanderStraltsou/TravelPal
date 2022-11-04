using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {


        public bool AllInclusive { get; set; }

        public Vacation(string destination, int travellers, Countries country, bool allInclusive) : base(destination, travellers, country)
        {
            AllInclusive = allInclusive;
        }

        //Send short info to the listView

        public override string GetInfo()
        {
            return $"{base.destination} / {base.travellers} / {base.country}";
        }
    }
}
