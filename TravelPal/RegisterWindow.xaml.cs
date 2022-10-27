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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        

        private UserManager userManager;

        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = pswPassword.Password;
            string confirmPassword = pswConfirmPassword.Password;

            this.userManager.AddUser(username, password, confirmPassword);

            Close();
        }
    }
}
