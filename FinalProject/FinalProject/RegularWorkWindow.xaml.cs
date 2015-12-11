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
    /// Interaction logic for RegularWorkWindow.xaml
    /// </summary>
    public partial class RegularWorkWindow : Window
    {
        private int enterpriseID;

        public RegularWorkWindow(int id)
        {
            InitializeComponent();
            enterpriseID = id;

        }

        private void logOutBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void mngAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            //create new window
            //show window
            this.Close();
        }
    }
}
