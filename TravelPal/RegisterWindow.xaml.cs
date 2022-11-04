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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        

        private UserManager userManager;
        private TravelManager travelManager;
        

        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;

            string[] countries = Enum.GetNames(typeof(Countries));

            cbLocations.ItemsSource = countries;


        }

        //Register user and check if the provided inormation is right

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string confirmPassword = pswConfirmPassword.Password;
            string locationString = cbLocations.SelectedItem.ToString();
            Countries location = (Countries)Enum.Parse(typeof(Countries), locationString);


            if (username.Length == 0 || password.Length == 0 || confirmPassword.Length == 0 || locationString == null)
            {
                MessageBox.Show("You have some empty fields left! Please, add all required info!", "Warning");
                return;
            }


            if (password == confirmPassword)
            {


                if (userManager.ValidateUsername(username))
                {
                    this.userManager.AddUser(username, password, location);

                    MainWindow mainWindow = new(userManager, travelManager);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username is invalid or already taken");
                }

            }


            else
            {
                MessageBox.Show("Password and Confirm Password fields don't match. Please, try again!", "Warning");
            }

            
        }

    }
}
