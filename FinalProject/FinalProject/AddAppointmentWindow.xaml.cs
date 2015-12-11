using EcoSystemClassLibrary;
using EcoSystemLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddAppointmentWindow.xaml
    /// </summary>
    public partial class AddAppointmentWindow : Window
    {
        private Enterprise enterprise;
        private Patient patient;
        private UserAccount doctor;
        private UserAccount nurse;
        private DateTime requestTime;

        public AddAppointmentWindow(Enterprise e)
        {
            InitializeComponent();
            enterprise = e;
            Init();
        }

        private void Init()
        {
            LoadPatientCombo();
            LoadDoctorCombo();
            LoadNurseCombo();
            AssignInitIDValue();
            CalibritDate();
            
        }

        private void CalibritDate()
        {
            CalibritCalender();
        }

        private void CalibritCalender()
        {
            appointmentCalender.SelectedDate = DateTime.Now;

        }

        private void LoadPatientCombo()
        {
            PatientDirectory pd = EcoSystemHelper.GetPatientFromTable(enterprise);
            foreach (Patient patient in pd.PatientList)
            {
                patientCombo.Items.Add(patient);
            }
        }

        private void LoadDoctorCombo()
        {
            UserAccountDirectory ua = EcoSystemHelper.GetDoctorUserAccountFromTable(enterprise);
            foreach (UserAccount user in ua.UserAccountList)
            {
                if (user.Role.Equals("Doctor"))
                {
                    doctorCombo.Items.Add(user);
                }
            }
        }

        private void LoadNurseCombo()
        {
            UserAccountDirectory ua = EcoSystemHelper.GetNurseUserAccountFromTable(enterprise);
            foreach (UserAccount user in ua.UserAccountList)
            {
                if (user.Role.Equals("Nurse"))
                {
                    nurseCombo.Items.Add(user);
                }
            }
        }

        private void AssignInitIDValue()
        {
            patientCombo.SelectedItem = 0;
            doctorCombo.SelectedItem = 0;
            nurseCombo.SelectedItem = 0;

            patient = (Patient)patientCombo.SelectedItem;
            doctor = (UserAccount)doctorCombo.SelectedItem;
            nurse = (UserAccount)nurseCombo.SelectedItem;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void patientCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient = (Patient)patientCombo.SelectedItem;
        }

        private void doctorCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctor = (UserAccount)doctorCombo.SelectedItem;
        }

        private void nurseCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nurse = (UserAccount)nurseCombo.SelectedItem;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string birthDateString = birthDateTxt.Text;
            string bloodType = bloodTypeTxt.Text;
            string reason = reasonTxt.Text;
            string costString = costTxt.Text;

            if (EcoSystemHelper.IsFourFieldsFilled(birthDateString, bloodType, reason, costString) == true)
            {
                if (EcoSystemHelper.IfAddAppointmentInputIsLegit(birthDateString, costString) == false)
                {
                    MessageBox.Show(this, "Wrong input format please check again", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    double cost = double.Parse(costString);
                    DateTime patientDOB = DateTime.Parse(birthDateString);

                    Appointment appointment = enterprise.AppointmentQueue.AddAppointment();
                    appointment.Patient = patient;
                    appointment.Doctor = doctor;
                    appointment.Nurse = nurse;
                    appointment.Cost = cost;
                    appointment.Reson = reason;
                    appointment.Name = "P" + patient.UserAccountID;
                    appointment.RequestDate = requestTime;
                    appointment.EnterpriseID = enterprise.EnterpriseID;
                    patient.BloodType = bloodType;
                    patient.Age = EcoSystemHelper.CalculateAge(patientDOB);


                    appointment.AppointmentID = EcoSystemHelper.GetPrimaryKeyInTable("AppointmentTable", "Name", appointment.Name, "AppointmentID");

                    EcoSystemHelper.AddAppointmentToTable(enterprise, appointment, patient);
                    //MessageBox.Show(this, "Appointment created", "Sucess!!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(this, "Please complete information", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string requestTimeString = appointmentCalender.SelectedDate.Value.ToString("yyyy-MM-dd hh:mm:ss");
            requestTime = DateTime.ParseExact(requestTimeString, "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
