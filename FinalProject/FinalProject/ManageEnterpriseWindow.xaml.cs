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
    /// Interaction logic for ManageEnterpriseWindow.xaml
    /// </summary>
    public partial class ManageEnterpriseWindow : Window
    {
        private EcoSystem business;

        public ManageEnterpriseWindow(EcoSystem b)
        {
            InitializeComponent();
            business = b;
            Init();
        }

        public void Init()
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            EnterpriseDirectory ed = EcoSystemHelper.GetEnterpriseDirectoryFromTable();
            var eList = ed.EnterpriseList;
            BindingList<Enterprise> bList = new BindingList<Enterprise>(eList);
            enterpriseGrid.ItemsSource = bList;
            enterpriseGrid.IsReadOnly = true;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEnterpriseWindow(business);
            window.ShowDialog();
            Init();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(enterpriseGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Enterprise enterprise = (Enterprise)enterpriseGrid.SelectedItems[0];

            int enterpriseID = enterprise.EnterpriseID;
            if (enterpriseID > 0)
            {
                if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    business.EnterpriseDirectory.RemoveEnterprise(enterprise);

                    EcoSystemHelper.RemoveEnterpriseFromBusinessClass(enterpriseID);
                    LoadDataGrid();
                }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (enterpriseGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Enterprise enterprise = (Enterprise)enterpriseGrid.SelectedItems[0];

            int enterpriseID = enterprise.EnterpriseID;
            if (enterpriseID > 0)
            {
                var window = new EditEnterpriseWindow(enterpriseID, business);
                window.ShowDialog();
                LoadDataGrid();
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new SystemAdminWindow(business);
            window.Show();
            this.Close();
        }
    }
}
