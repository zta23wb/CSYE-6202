using EcoSystemClassLibrary;
using EcoSystemLibrary;
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for EditEnterpriseAdministratorWindow.xaml
    /// </summary>
    public partial class EditEnterpriseAdministratorWindow : Window
    {
        private int userID;
        private EcoSystem business;
        private int enterpriseID;

        public EditEnterpriseAdministratorWindow(int id, int ed, EcoSystem b)
        {
            InitializeComponent();
            business = b;
            userID = id;
            enterpriseID = ed;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string password = passwordTxt.Text;
            if (EcoSystemHelper.IsTwoFieldsFilled(name, password) == true)
            {
                Enterprise en = business.EnterpriseDirectory.SearchEnterprise(enterpriseID);
                UserAccount ua = en.UserAccountDirectory.SearchUser(userID);
                ua.Password = password;
                ua.Name = name;
                EcoSystemHelper.EditEnterpriseAdminInBusiness(ua);
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
