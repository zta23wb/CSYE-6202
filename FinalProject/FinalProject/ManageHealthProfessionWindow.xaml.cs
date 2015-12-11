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
    /// Interaction logic for ManageHealthProfessionWindow.xaml
    /// </summary>
    public partial class ManageHealthProfessionWindow : Window
    {
        private Enterprise enterprise;
        private UserAccount useraccount;

        public ManageHealthProfessionWindow(Enterprise e, UserAccount ua)
        {
            InitializeComponent();
            enterprise = e;
            useraccount = ua;
            Init();
        }

        private void Init()
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            UserAccountDirectory ud = EcoSystemHelper.GetHealthProfessionUserFromTable(enterprise);
            var list = ud.UserAccountList;
            BindingList<UserAccount> bList = new BindingList<UserAccount>(list);
            healthProfessionGrid.ItemsSource = bList;
            healthProfessionGrid.IsReadOnly = true;
               
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new EnterpriseAdministratorWorkWindow(enterprise, useraccount);
            window.Show();
            this.Close();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (healthProfessionGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            UserAccount userAccount = (UserAccount)healthProfessionGrid.SelectedItem;
            if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                EcoSystemHelper.RemoveHealthProfessionFromTable(enterprise, userAccount);
                enterprise.UserAccountDirectory.RemoveUser(useraccount.UserAccountID);
                LoadGrid();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (healthProfessionGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            UserAccount userAccount = (UserAccount)healthProfessionGrid.SelectedItem;
            
            var window = new EditHelathProfessionWindow(userAccount);
            window.ShowDialog();
            LoadGrid();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddHealthProfessionWidown(enterprise);
            window.ShowDialog();
            LoadGrid();
        }
    }
}
