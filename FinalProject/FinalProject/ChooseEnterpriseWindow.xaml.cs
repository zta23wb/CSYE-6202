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
    /// Interaction logic for ChooseEnterpriseWindow.xaml
    /// </summary>
    public partial class ChooseEnterpriseWindow : Window
    {
        private Enterprise enterprise;
        private UserAccount useraccount;
       

        public ChooseEnterpriseWindow(UserAccount ua)
        {
            InitializeComponent();
            useraccount = ua;
            Init();
        }

        public void Init()
        {
            LoadCombo();
            enterprise = (Enterprise)enterpriseCombo.SelectedItem;
        }

        public void LoadCombo()
        {
            List<Enterprise> ed = EcoSystemHelper.GetEnterpriseFromTable();
            foreach(Enterprise e in ed)
            {
                enterpriseCombo.Items.Add(e);
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void goBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new EnterpriseAdministratorWorkWindow(enterprise, useraccount);
            window.Show();
            this.Close();
        }

        private void enterpriseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enterprise = (Enterprise)enterpriseCombo.SelectedItem;
        }

    }
}
