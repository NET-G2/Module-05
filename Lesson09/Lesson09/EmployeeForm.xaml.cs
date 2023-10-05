using Lesson09.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Lesson09
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        List<ManagerCombobox> managersList = new List<ManagerCombobox>();
        List<int> departmentsList = new List<int>();

        CompanyEntities1 db = new CompanyEntities1();

        public EmployeeForm()
        {
            InitializeComponent();

            managersList = db.emp
                .OrderBy(x => x.ename)
                .Select(x => new ManagerCombobox
                {
                    Empno = x.empno,
                    Ename = x.ename
                })
                .ToList();
            departmentsList = db.emp
                .Select(x => x.deptno)
                .Distinct()
                .ToList();

            managers.ItemsSource = managersList;
            departments.ItemsSource = departmentsList;
        }

        public EmployeeForm(emp empToUpdate)
            : this()
        {
            empno.Text = empToUpdate.empno.ToString();
            eName.Text = empToUpdate.ename.ToString();
            job.Text = empToUpdate.job.ToString();
            sal.Text = empToUpdate.sal.ToString();
            hiredate.SelectedDate = empToUpdate.hiredate;
            comm.Text = empToUpdate.comm.ToString();

            var currentManager = managersList.FirstOrDefault(x => x.Empno == empToUpdate.mgr); 
            if (currentManager != null)
            {
                managers.SelectedItem = currentManager;
            }

            var currentDept = departmentsList.FirstOrDefault(x => x == empToUpdate.deptno);

            departments.SelectedItem = currentDept;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedManager = managers.SelectedValue;

                emp newEmp = new emp();
                newEmp.empno = int.Parse(empno.Text);
                newEmp.ename = eName.Text.ToString();
                newEmp.job = job.Text.ToString();
                newEmp.mgr = int.Parse(managers.SelectedValue.ToString());
                newEmp.sal = decimal.Parse(sal.Text);
                newEmp.comm = decimal.Parse(comm.Text);
                newEmp.hiredate = hiredate.SelectedDate;
                newEmp.deptno = int.Parse(departments.SelectedItem.ToString());

                db.emp.AddOrUpdate(newEmp);
                db.SaveChanges();

                MessageBox.Show($"{newEmp.ename} was saved.", "Success", MessageBoxButton.OK);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK);
            }
        }
    }

    class ManagerCombobox
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string DisplayValue
        {
            get => $"{Empno} ({Ename})";
        }
        public int SelectedValue
        {
            get => Empno;
        }
    }

    class DepartmentCombobox
    {
        public int Deptno { get; set; }
        public string Dname { get; set; }
    }
}
