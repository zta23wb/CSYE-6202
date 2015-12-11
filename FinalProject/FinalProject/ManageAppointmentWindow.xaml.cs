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
    /// Interaction logic for ManageAppointmentWindow.xaml
    /// </summary>
    public partial class ManageAppointmentWindow : Window
    {
        private Enterprise enterprise;
        private UserAccount useraccount;

        public ManageAppointmentWindow(Enterprise e, UserAccount ua)
        {
            InitializeComponent();
            enterprise = e;
            useraccount = ua;
            Init();
        }

        public void Init()
        {
            LoadDataGrid();
            if(useraccount.Role.Equals("Nurse"))
            {
                ActivateNurseMode();
            }
        }

        public void LoadDataGrid()
        {
            AppointmentQueue aq = EcoSystemHelper.GetAppointmentQueueFromTable(enterprise);
            var aList = aq.AppointmentList;
            BindingList<Appointment> bList = new BindingList<Appointment>(aList);
            appointmentGrid.ItemsSource = bList;
            appointmentGrid.IsReadOnly = true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new EnterpriseAdministratorWorkWindow(enterprise, useraccount);
            window.Show();
            this.Close();
        }

        private void viewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Appointment appointment = (Appointment)appointmentGrid.SelectedItem;

            var window = new ViewAppointmentWindow(appointment, enterprise);
            window.ShowDialog();
            LoadDataGrid();
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Appointment appointment = (Appointment)appointmentGrid.SelectedItem;

          
            if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
              {
                enterprise.AppointmentQueue.RemoveAppointment(appointment);
                EcoSystemHelper.RemoveAppointmentFromTable(enterprise, appointment);
                  LoadDataGrid();
              }
            
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentGrid.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select a row first", "Warning!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Appointment appointment = (Appointment) appointmentGrid.SelectedItem;
            var window = new EditOptionWindow(appointment);
            window.ShowDialog();
            LoadDataGrid();
        }

        public void ActivateRegularMode()
        {
            editBtn.IsEnabled = false;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddAppointmentWindow(enterprise);
            window.ShowDialog();
            LoadDataGrid();
        }

        public void ActivateNurseMode()
        {
            editBtn.IsEnabled = false;
            editBtn.Visibility = Visibility.Hidden;
            editBtn.Visibility = Visibility.Collapsed;
        }
    }
}
