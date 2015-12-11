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
    /// Interaction logic for AddHealthProfessionWidown.xaml
    /// </summary>
    public partial class AddHealthProfessionWidown : Window
    {
        private string role;
        private Enterprise enterprise;


        public AddHealthProfessionWidown(Enterprise e)
        {
            InitializeComponent();
            enterprise = e;
            role = null;
            Init();
        }

        private void Init()
        {
            LoadComboBox();
            roleCombo.SelectedIndex = 0;
        }

        private void LoadComboBox()
        {
            roleCombo.ItemsSource = EcoSystemHelper.GetRoleComboList();

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            role = roleCombo.SelectedItem.ToString();
            string name = nameTxt.Text;
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            if (EcoSystemHelper.IsThreeFieldsFilled(username, password, name))
            {
              if (EcoSystemHelper.FindStringInGivenTable("UserAccountTable", "Username", username) == true)
                  {
                        MessageBox.Show(this, "Username already exist in database, plase enter a new one", "Warning!",
                       MessageBoxButton.OK, MessageBoxImage.Information);
                  }
                  else
                  {
                    UserAccount ua = enterprise.UserAccountDirectory.AddUserAccount();
                    ua.Username = username;
                    ua.Password = password;
                    ua.Name = name;
                    ua.Role = role;
                    ua.EnterpriseID = enterprise.EnterpriseID;
                    EcoSystemHelper.AddUserIntoTable(ua.Username, ua.Password, ua.Role, enterprise.EnterpriseID, ua.Name);
                    ua.UserAccountID = EcoSystemHelper.GetPrimaryKeyInTable("UserAccountTable", "Name", ua.Name, "UserID");
                    if (ua.Role.Equals("Patient"))
                    {
                        Patient patient = enterprise.patientDirectory.AddPatient();
                        patient.UserAccountID = ua.UserAccountID;
                        patient.Name = ua.Name;
                        EcoSystemHelper.AddPatientIntoBusiness(enterprise, ua);
                    }
                    this.Close();
                  }
            }
            else
            {
                MessageBox.Show(this, "Please complete information", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
