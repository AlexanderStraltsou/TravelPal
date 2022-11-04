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
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;

        public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel travel)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            cbTripType.Visibility = Visibility.Hidden;
            xbAllInclusive.Visibility = Visibility.Hidden;

            cbTripType.ItemsSource = Enum.GetNames(typeof(TripTypes));
            cbTravelType.ItemsSource = Enum.GetNames(typeof(TravelTypes));

            cbTravelType.SelectedItem = travel.GetType().Name;

            txtDestination.Text = travel.destination;
            txtTravellers.Text = travel.travellers.ToString();

            cbCountry.ItemsSource = Enum.GetValues(typeof(Countries));
            cbCountry.SelectedIndex = cbCountry.Items.IndexOf(travel.country);


            //Change visibility depending on travel type

            if(travel is Trip)
            {
                cbTripType.Visibility = Visibility.Visible;
                Trip trip = travel as Trip;
                cbTripType.SelectedItem = trip.Type.ToString();
            }
            else if(travel is Vacation)
            {
                xbAllInclusive.Visibility = Visibility.Visible;
                Vacation vacation = travel as Vacation;
                xbAllInclusive.IsChecked = vacation.AllInclusive;
            }

        }

        //Close TravelDetails window and open TravelWindow

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow TravelsWindow = new(userManager, travelManager);

            TravelsWindow.Show();

            Close();
        }
    }
}
