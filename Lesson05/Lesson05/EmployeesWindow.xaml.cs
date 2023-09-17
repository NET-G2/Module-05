using Lesson05.Models;
using System.Collections.Generic;
using System.Windows;

namespace Lesson05
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        public EmployeesWindow()
        {
            InitializeComponent();
        }

        public EmployeesWindow(List<Employee> employees)
            : this()
        {
            this.empDataGrid.ItemsSource = employees;
        }
    }
}
