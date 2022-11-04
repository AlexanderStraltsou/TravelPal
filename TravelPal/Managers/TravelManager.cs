using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        // Get travels från Travel lista
        public List<Travel> GetTravels()
        {
            return travels;
        }

        // Remove Travel från listan
        public void RemoveTravel(Travel travelToDelete)
        {
            travels.Remove(travelToDelete);
        }

        // Lägg till trip till listan
        public Travel AddTravel(string destination, int travellersInt, Countries country, TripTypes tripType)
        {
            Trip trip = new(destination, travellersInt, country, tripType);

            travels.Add(trip);

            return trip;
        }

        // Lägg till vacation till listan
        public Travel AddTravel(string destination, int travellersInt, Countries country, bool allInclusive)
        {
            Vacation vacation = new(destination, travellersInt, country, allInclusive);

            travels.Add(vacation);

            return vacation;
        }
    }
}
