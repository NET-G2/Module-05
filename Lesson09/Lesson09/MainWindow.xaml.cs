using Lesson09.DAL;
using System.Linq;
using System.Windows;

namespace Lesson09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CompanyEntities1 database = new CompanyEntities1();
        public MainWindow()
        {
            InitializeComponent();

            employeesDataGrid.ItemsSource = database.emp.ToList();
        }

        private void employeesDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedEmp = employeesDataGrid.SelectedItem as emp;

            var form = new EmployeeForm(selectedEmp);

            form.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();

            employeesDataGrid.ItemsSource = database.emp.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = employeesDataGrid.SelectedItem as emp;
            if (selectedItem != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete?", "Confirm your action", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    database.emp.Remove(selectedItem);
                    database.SaveChanges();

                    MessageBox.Show($"Employee {selectedItem.ename} was deleted.", "Success", MessageBoxButton.OK);

                    employeesDataGrid.ItemsSource = database.emp.ToList();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
