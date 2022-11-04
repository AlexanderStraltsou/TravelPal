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
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        private List<Travel> travels = new();
        
        public TravelsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;

            if(userManager.SignedInUser is Admin)
            {
                travels = travelManager.GetTravels();
            }
            else if (userManager.SignedInUser is User)
            {
                User signedInUser = userManager.SignedInUser as User;
                travels = signedInUser.Travels;
            }

            foreach (Travel travel in travels)
            {
                ListViewItem item = new();

                item.Content = travel.GetInfo();
                item.Tag = travel;

                lvTravel.Items.Add(item);
            }
            

            //Show the name of signed in user

            lblUsername.Content = userManager.SignedInUser.Username;


        }


        //Open AddTravelWindow to add a new travel and close TravelsWindow


        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new(userManager, travelManager);

            addTravelWindow.Show();

            this.Close();
        }


        //Open a little window with short info about the app and company

        private void btnAppInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Visit our website www.travelpal.com for more info about our company.", "Learn more about us:");
        }

        //Check details of selected travel, check if travel is selected. Open TravelDetails window and close TravelsWindow

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvTravel.SelectedItem as ListViewItem;

            if(selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, selectedTravel);

                travelDetailsWindow.Show();

                Close();
            }
            else
            {
                MessageBox.Show("First select a travel");
            }
        }

        //Open User Details window and close TravelsWIndow

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);

            userDetailsWindow.Show();

            Close();
        }

        // Sign out current user, close window and open main window again

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            userManager.SignedInUser = null;

            MainWindow mainWindow = new(userManager, travelManager);
            mainWindow.Show();

            Close();
        }

        //Show Updated Travels in the list after we removed something
        private void ShowUpdatedTravels()

        {
            travels = travelManager.GetTravels();

            foreach (Travel travel in travels)
            {
                ListViewItem item = new();


                item.Content = travel.GetInfo();
                item.Tag = travel;

                lvTravel.Items.Add(item);
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Check which travel is selected

            ListViewItem selectedItem = lvTravel.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {

                Travel selectedTravel = selectedItem.Tag as Travel;

                //Remove travel
                
                travelManager.RemoveTravel(selectedTravel);

                //Show Updated List of Travels

                lvTravel.Items.Clear();
                ShowUpdatedTravels();

            }
            else
            {
                MessageBox.Show("First select a travel");
            }

        }

        //Buttons remove and details are hidden if travel is selected

        private void lvTravel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnDetails.IsEnabled = true;
        }
    }
}
