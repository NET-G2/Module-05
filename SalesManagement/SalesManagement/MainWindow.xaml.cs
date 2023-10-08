using SalesManagement.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            contentControl.Content = new DashboardView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Dasturni yopishni istaysizmi?", "Amalni tastiqlang", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (contentControl != null)
                contentControl.Content = new DashboardView();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (contentControl != null)
                contentControl.Content = new CustomersView();
        }
    }
}
