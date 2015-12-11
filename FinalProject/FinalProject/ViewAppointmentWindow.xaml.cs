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
    /// Interaction logic for ViewAppointmentWindow.xaml
    /// </summary>
    public partial class ViewAppointmentWindow : Window
    {
        private Appointment appointment;
        private Enterprise enterprise;

        public ViewAppointmentWindow(Appointment a, Enterprise e)
        {
            InitializeComponent();
            appointment = a;
            enterprise = e;
            LoadFields();
        }

        public  void LoadFields()
        {
            Patient patient = (Patient) appointment.Patient;
            patientIDTxt.Text = patient.UserAccountID.ToString();
            
            patientNameTxt.Text = patient.Name;


            string bloodType = patient.BloodType.ToString();
            string age = Convert.ToString(patient.Age);
            bloodTypeTxt.Text = bloodType;
            ageTxt.Text = age;
            if (appointment.Doctor != null)
            {
                doctorIDTxt.Text = appointment.Doctor.UserAccountID.ToString();
            }
            if (appointment.Nurse != null)
            {
                nurseIDTxt.Text = appointment.Nurse.UserAccountID.ToString();
            }
            reasonTxt.Text = appointment.Reson;
            dateTxt.Text = appointment.RequestDate.ToString();
            costTxt.Text = appointment.Cost.ToString();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
