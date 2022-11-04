using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {

        private readonly TravelManager travelManager;
        private UserManager userManager;
        
        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
            

            string[] countries = System.Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource = countries;

            string[] tripTypes =System.Enum.GetNames(typeof(TripTypes));

            cbTripType.ItemsSource = tripTypes;

            string[] travelTypes = System.Enum.GetNames(typeof(TravelTypes));

            cbTravelType.ItemsSource = travelTypes;

        }

        // Add/Save new travel

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtDestination.Text;
            string travellers = txtTravellers.Text;
            string country = cbCountry.SelectedItem as string;
            Countries countriesEnum = (Countries)System.Enum.Parse(typeof(Countries), country);

            string travelType = cbTravelType.SelectedItem as string;

            try
            {
                int travellersInt = int.Parse(travellers);

                if (travelType == "Trip")
                {
                    string tripType = cbTripType.SelectedItem as string;

                    TripTypes tripTypeEnum = (TripTypes)System.Enum.Parse(typeof(TripTypes), tripType);

                    Travel newTravel = travelManager.AddTravel(destination, travellersInt, countriesEnum, tripTypeEnum);

                    User signedInUser = userManager.SignedInUser as User;

                    signedInUser.Travels.Add(newTravel);

                }
                else if (travelType == "Vacation")
                {
                    bool allInclusive = false;

                    if ((bool)xbAllInclusive.IsChecked)
                    {
                        allInclusive = true;
                    }

                    Travel newTravel = travelManager.AddTravel(destination, travellersInt, countriesEnum, allInclusive);

                    User signedInUser = userManager.SignedInUser as User;

                    signedInUser.Travels.Add(newTravel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Travellers should be a number!");

                return;
            }

            // Open travels window again, close addTravel window

            TravelsWindow TravelsWindow = new(userManager, travelManager);

            TravelsWindow.Show();
      
            this.Close();
        }


        //Change visibily depending on selection in the comboboxes

        private void cbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTravelTypeString = cbTravelType.SelectedItem as string;

            if(selectedTravelTypeString == "Trip")
            {
                cbTripType.Visibility = Visibility.Visible;
                xbAllInclusive.Visibility = Visibility.Hidden;
            }
            else if (selectedTravelTypeString == "Vacation")
            {
                xbAllInclusive.Visibility = Visibility.Visible;
                cbTripType.Visibility = Visibility.Hidden;
            }
        }

    }
}
