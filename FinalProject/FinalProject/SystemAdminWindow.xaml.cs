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
    /// Interaction logic for SystemAdminWindow.xaml
    /// </summary>
    public partial class SystemAdminWindow : Window
    {
        private EcoSystem business;

        public SystemAdminWindow(EcoSystem b)
        {
            InitializeComponent();
            business = b;
            
        }


        private void logOutBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }


        private void mngEnterpriseBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ManageEnterpriseWindow(business);
            window.Show();
            this.Close();
        }

        private void mngEnterpriseAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ManageEnterpriseAdminWindow(business);
            window.Show();
            this.Close();
        }
    }
}
