using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    /// 
    

    public partial class UserDetailsWindow : Window
    {
        

        private Managers.UserManager userManager;
        private TravelManager travelManager;


        public UserDetailsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            string[] countries = Enum.GetNames(typeof(Countries));

            cbLocations.ItemsSource = countries;

            IUser user = userManager.SignedInUser;

            txtUsername.Text = user.Username;

            cbLocations.ItemsSource = Enum.GetValues(typeof(Countries));
            cbLocations.SelectedIndex = cbLocations.Items.IndexOf(user.Location);

        }

        //Close user details window and open TravelsWindow again

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            TravelsWindow TravelsWindow = new(userManager, travelManager);

            TravelsWindow.Show();

            this.Close();
        }

        //Save updated user details and double check if provided information is right

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string confirmPassword = pswConfirmPassword.Password;
            string locationString = cbLocations.SelectedItem.ToString();
            Countries location = (Countries)Enum.Parse(typeof(Countries), locationString);


            if (pswPassword.Password != userManager.SignedInUser.Password && txtUsername.Text != userManager.SignedInUser.Username)
            {
                if(userManager.updatePassword(userManager.SignedInUser, pswPassword.Password))
                {
                    userManager.updateUsername(userManager.SignedInUser, txtUsername.Text);
                }
            }


            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password fields don't match. Please, try again!", "Warning");
            }

            else if (username.Length == 0 || password.Length == 0 || confirmPassword.Length == 0 || locationString == null)
            {
                MessageBox.Show("You have some empty fields left! Please, add all required info!", "Warning");
            }

            else if (password.Length >= 1 && password.Length <= 4 )
            {
                MessageBox.Show("Your password must be at least 5 characters.", "Warning");
            }

            else if (username.Length >= 1 && username.Length <= 2)
            {
                MessageBox.Show("Your login must be at least 3 characters.", "Warning");
            }

            else
            {

                TravelsWindow TravelsWindow = new(userManager, travelManager);

                TravelsWindow.Show();

                this.Close();
  
            }
        }
    }
}

