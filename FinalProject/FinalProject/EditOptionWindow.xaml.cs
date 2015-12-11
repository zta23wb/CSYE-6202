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
    /// Interaction logic for EditOptionWindow.xaml
    /// </summary>
    public partial class EditOptionWindow : Window
    {
        private Appointment appointment;
        
        public EditOptionWindow(Appointment a)
        {
            InitializeComponent();
            appointment = a;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditAppointmentWindow(appointment);
            window.ShowDialog();
        }

        private void deleteReasonBtn_Click(object sender, RoutedEventArgs e)
        {
            appointment.Reson = null;
            EcoSystemHelper.DeleteReasonOfAppointmentInTable(appointment);
            this.Close();
        }

        private void deleteCostBtn_Click(object sender, RoutedEventArgs e)
        {
            appointment.Cost = 0.0;
            EcoSystemHelper.DeleteCostOfAppointmentInTable(appointment);
            this.Close();
        }
    }
}
