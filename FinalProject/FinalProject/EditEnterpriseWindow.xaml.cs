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
    /// Interaction logic for EditEnterpriseWindow.xaml
    /// </summary>
    public partial class EditEnterpriseWindow : Window
    {
        private int enterpriseID;
        private EcoSystem business;

        public EditEnterpriseWindow(int id, EcoSystem b)
        {
            InitializeComponent();
            business = b;
            enterpriseID = id;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string location = locationTxt.Text;
            if(EcoSystemHelper.IsTwoFieldsFilled(name, location) == true)
            {
                if(EcoSystemHelper.FindStringInGivenTable("EnterpriseTable", "Name", name) == true)
                {
                    MessageBox.Show(this, "Name already exist in database, plase enter a new name", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }else
                {
                    EnterpriseDirectory ed = EcoSystemHelper.GetEnterpriseDirectoryFromTable();
                    Enterprise enterprise = ed.SearchEnterprise(enterpriseID);
                    enterprise.Name = name;
                    enterprise.Location = location;
                    EcoSystemHelper.EditEnterpriseFromBusinessClass(enterprise, name, location);
                    this.Close();
                }
            }else
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
