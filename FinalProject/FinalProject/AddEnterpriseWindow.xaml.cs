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
    /// Interaction logic for AddEnterpriseWindow.xaml
    /// </summary>
    public partial class AddEnterpriseWindow : Window
    {
        private EcoSystem business;

        public AddEnterpriseWindow(EcoSystem b)
        {
            InitializeComponent();
            business = b;
        }

        public void Init()
        {
            warningTxt.Content = "";
            nameTxt.Text = "";
            locationTxt.Text = "";
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string location = locationTxt.Text;

            if(EcoSystemHelper.IsTwoFieldsFilled(name, location) == true)
            {
                if (EcoSystemHelper.FindStringInGivenTable("EnterpriseTable", "Name", name) == true)
                {
                        MessageBox.Show(this, "The name alreay exsit, please use a new name", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                        nameTxt.Text = "";
                        nameTxt.Focus();
                        return;
                }else
                {
                    Enterprise en = business.EnterpriseDirectory.AddEnterprise();
                    en.Name = name;
                    en.Location = location;
                    EcoSystemHelper.AddEnterpriseIntoBusinessClass(en);
                }
                 //MessageBox.Show(this, "Enterprise created", "Sucess!!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Please complete information", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            nameTxt.Background = Brushes.White;
        }
    }
}
