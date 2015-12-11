using EcoSystemClassLibrary;
using EcoSystemLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for EditHelathProfessionWindow.xaml
    /// </summary>
    public partial class EditHelathProfessionWindow : Window
    {
        private UserAccount userAccount;

        public EditHelathProfessionWindow(UserAccount ua)
        {
            InitializeComponent();
            userAccount = ua;
            LoadFields();
        }

        private void LoadFields()
        {
            usernameTxt.Text = userAccount.Username;
            passwordTxt.Text = userAccount.Password;
            nameTxt.Text = userAccount.Name;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string password = passwordTxt.Text;
            if (EcoSystemHelper.IsTwoFieldsFilled(password, name) == true)
            {
                userAccount.Password = password;
                userAccount.Name = name;
                EcoSystemHelper.EditUserInBusiness(userAccount, password, name);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
