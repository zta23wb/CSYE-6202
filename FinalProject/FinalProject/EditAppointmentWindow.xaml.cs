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
    /// Interaction logic for EditAppointmentWindow.xaml
    /// </summary>
    public partial class EditAppointmentWindow : Window
    {
        private Appointment appointment;

        public EditAppointmentWindow(Appointment a)
        {
            InitializeComponent();
            appointment = a;
            Init();
        }
        private void Init()
        {
            FillFields();
        }

        private void FillFields()
        {
            reasonTxt.Text = appointment.Reson;
            costTxt.Text = appointment.Cost.ToString();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            string reason = reasonTxt.Text;
            if (EcoSystemHelper.IsFieldFilled(reason) == true)
            {
                appointment.Reson = reason;
                EcoSystemHelper.EditReasonInAppointment(appointment, reason);
                MessageBox.Show(this, "Operation Completed", "Completed!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void editCostBtn_Click(object sender, RoutedEventArgs e)
        {
            string costString = costTxt.Text;
            if (EcoSystemHelper.IsFieldFilled(costString) == true)
            {
                if (EcoSystemHelper.IsInputLegitDouble(costString) == false)
                {
                    MessageBox.Show(this, "Wrong input information, please enter again", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Double cost = Convert.ToDouble(costString);
                    appointment.Cost = cost;
                    EcoSystemHelper.EditCostInAppointment(appointment, cost);
                    MessageBox.Show(this, "Operation Completed", "Completed!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Please fill in all the fields", "Warning!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
