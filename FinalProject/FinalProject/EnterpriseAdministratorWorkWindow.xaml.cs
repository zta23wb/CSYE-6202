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
    /// Interaction logic for EnterpriseAdministratorWorkWindow.xaml
    /// </summary>
    public partial class EnterpriseAdministratorWorkWindow : Window
    {
        private Enterprise enterprise;
        private UserAccount useraccoumt;

        public EnterpriseAdministratorWorkWindow(Enterprise en, UserAccount ua)
        {
            InitializeComponent();
            enterprise = en;
            useraccoumt = ua;
            Init();
        }

        private void Init()
        {
            if(useraccoumt.Role.Equals("Nurse"))
            {
                ActivateNurseMode();
            }
        }

        private void logOutBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChooseEnterpriseWindow(useraccoumt);
            window.Show();
            this.Close();
        }

        private void mngAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ManageAppointmentWindow(enterprise, useraccoumt);
            window.Show();
            this.Close();
        }

        private void mngHealthProfessionBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new ManageHealthProfessionWindow(enterprise, useraccoumt);
            window.Show();
            this.Close();
        }

        public void ActivateNurseMode()
        {
            mngHealthProfessionBtn.IsEnabled = false;
            mngHealthProfessionBtn.Visibility = Visibility.Hidden;
            mngHealthProfessionBtn.Visibility = Visibility.Collapsed;
        }
    }
}
