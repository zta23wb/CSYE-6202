using EcoSystemClassLibrary;
using EcoSystemLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserAccount user;
        private EcoSystem business;

        public MainWindow()
        {
            InitializeComponent();
            user = null;
            business = EcoSystemHelper.GetInstance();
            usernameTxt.Focus();
        }

        private void Init()
        {
           
        }

        private void usernameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            usernameTxt.Background = Brushes.Cyan;
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordBox.Background = Brushes.Cyan;
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            TryToLogIn();
        }

        private void TryToLogIn()
        {
            string username = usernameTxt.Text;
            string password = passwordBox.Password;
            if(EcoSystemHelper.IsTwoFieldsFilled(username, password) == false)
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                usernameTxt.Text = "";
                passwordBox.Password = "";
                usernameTxt.Focus();
                return;
            }

            user = EcoSystemHelper.AuthenticateUser(business, username, password);
            if (user == null)
            {
                MessageBox.Show(this, "Wrong log in information, please check again", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                usernameTxt.Text = "";
                passwordBox.Password = "";
                usernameTxt.Focus();
            }
            else
            {
                string userRole = user.Role;
                NavigateRoleWindow(userRole);
            }
        }


        private void NavigateRoleWindow(string s)
        {
            if (s.Equals("System Administration"))
            {
                var window = new SystemAdminWindow(business);
                window.Show();
                this.Close();
            }
            else if (s.Equals("Enterprise Administrator"))
            {
                var window = new ChooseEnterpriseWindow(user);
                window.Show();
                this.Close();
            }
            else if (s.Equals("Nurse"))
            {
                var window = new ChooseEnterpriseWindow(user);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "user is not null, but not navigating", "Warning!",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void signInBtn_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        }
    }
}
