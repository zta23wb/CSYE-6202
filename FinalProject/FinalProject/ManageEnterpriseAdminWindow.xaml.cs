using EcoSystemClassLibrary;
using EcoSystemLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for ManageEnterpriseAdminWindow.xaml
    /// </summary>
    public partial class ManageEnterpriseAdminWindow : Window
    {
        private EcoSystem business;

        public ManageEnterpriseAdminWindow(EcoSystem b)
        {
            InitializeComponent();
            business = b;
            Init();
        }

        public void Init()
        {
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            enterpriseAdminGrid.AutoGenerateColumns = true;
            var enterpriseAdminList = EcoSystemHelper.GetEnterpriseAdminFromBusiness();
            BindingList<UserAccount> bList = new BindingList<UserAccount>(enterpriseAdminList);
            enterpriseAdminGrid.ItemsSource = bList;
            enterpriseAdminGrid.IsReadOnly = true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new SystemAdminWindow(business);
            window.Show();
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEnterpriseAdminWindow(business);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (enterpriseAdminGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            UserAccount userAccount = (UserAccount) enterpriseAdminGrid.SelectedItem;
            int userID = userAccount.UserAccountID;
            int enterpriseID = userAccount.EnterpriseID;
            if (userID > 0)
            {
                if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Enterprise en = business.EnterpriseDirectory.SearchEnterprise(enterpriseID);
                    if (en != null)
                    {
                        en.UserAccountDirectory.RemoveUser(userID);
                    }
                    EcoSystemHelper.RemoveEnterpriseAdminFromBusiness(userID);
                    LoadDataGrid();
                }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (enterpriseAdminGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            UserAccount userAccount = (UserAccount)enterpriseAdminGrid.SelectedItem;
            int userID = userAccount.UserAccountID;
            int enterpriseID = userAccount.EnterpriseID;
            var window = new EditEnterpriseAdministratorWindow(userID, enterpriseID, business);
            window.ShowDialog();
            LoadDataGrid();
        }
    }
}
