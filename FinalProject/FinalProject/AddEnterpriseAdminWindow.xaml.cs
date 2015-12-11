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
    /// Interaction logic for AddEnterpriseAdminWindow.xaml
    /// </summary>
    public partial class AddEnterpriseAdminWindow : Window
    {
        private Enterprise enterprise;
        private EcoSystem business;

        public AddEnterpriseAdminWindow(EcoSystem b)
        {
            InitializeComponent();
            business = b;
            Init();
        }

        public void Init()
        {
            LoadComboBox();
            enterprise = (Enterprise)enterpriseCombo.SelectedItem;
        }

        public void LoadComboBox()
        {
            EnterpriseDirectory ed = EcoSystemHelper.GetEnterpriseDirectoryFromTable();
            var eList = ed.EnterpriseList;
            foreach (Enterprise enterprise in eList)
            {
                enterpriseCombo.Items.Add(enterprise);
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;
            string name = nameTxt.Text;
            if(EcoSystemHelper.IsThreeFieldsFilled(username, password, name) == true)
            {
                if(EcoSystemHelper.FindStringInGivenTable("UserAccountTable", "Username", username) == true)
                {
                    MessageBox.Show(this, "The name alreay exists, please use a new name", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    UserAccount ua = enterprise.UserAccountDirectory.AddUserAccount();
                    ua.Username = username;
                    ua.Password = password;
                    ua.Name = name;
                    ua.Role = "Enterprise Administrator";
                    ua.EnterpriseID = enterprise.EnterpriseID;
                    EcoSystemHelper.AddUserIntoTable(ua.Username, ua.Password, ua.Role, enterprise.EnterpriseID, ua.Name);
                    ua.UserAccountID = EcoSystemHelper.GetPrimaryKeyInTable("UserAccountTable", "Name", ua.Name, "UserID");
                    //MessageBox.Show(this, "Created!", "Completed!",
                   //MessageBoxButton.OK, MessageBoxImage.Information);
                    ResetFields();
                }
            }else
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void enterpriseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enterprise = (Enterprise) enterpriseCombo.SelectedItem;
            
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ResetFields()
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            nameTxt.Text = "";
        }
    }
}
