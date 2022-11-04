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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;

        public MainWindow()
        {
            InitializeComponent();
            this.userManager = new();
            this.travelManager = new();

            foreach(IUser user in userManager.GetAllUsers())
            {
                if(user is User)
                {
                    User u = user as User;

                    travelManager.travels.AddRange(u.Travels);
                }
            }
        }

        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelManager = travelManager;
            
        }

        // Register/Save user and close register window

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {


            RegisterWindow registerWindow = new(userManager, travelManager);

            registerWindow.Show();

            this.Close();

        }


        //Sign in as a user, close login/main window and open travelsWindow. Show warning if something isn't right

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            List<IUser> users = userManager.GetAllUsers();

            string username = txtUsername.Text;
            string password = pswPassword.Password;

            bool isFoundUser = false;

            foreach (IUser user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    
                    isFoundUser = true;
                    userManager.SignedInUser = user;

                    TravelsWindow travelsWindow = new(userManager, travelManager);

                    travelsWindow.Show();

                    Close();
                    
                }
            }

            if (!isFoundUser)
            {
                MessageBox.Show("User doesn't exist or username/password is incorrect", "Warning");
            }
        }
    }

    
}
