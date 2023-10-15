using Lesson11.Models;
using Lesson11.Services;
using Lesson11.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lesson11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EnrollmentDbService _dbService;
        private readonly StudentDbService _studentsService;
        private readonly SubjectsDbService _subjectsService;
        private ObservableCollection<Enrollment> _enrollments;
        private ObservableCollection<Student> _students;
        private ObservableCollection<Subject> _subjects;

        public MainWindow()
        {
            InitializeComponent();

            _enrollments = new ObservableCollection<Enrollment>();
            _students = new ObservableCollection<Student>();
            _subjects = new ObservableCollection<Subject>();
            _dbService = new EnrollmentDbService();
            _subjectsService = new SubjectsDbService();
            _studentsService = new StudentDbService();

            LoadData();
        }

        public void LoadData()
        {
            _enrollments.Clear();
            _students.Clear();
            _subjects.Clear();
            _enrollments = new ObservableCollection<Enrollment>(_dbService.GetActiveEnrollments());
            _students = new ObservableCollection<Student>(_studentsService.GetStudents());
            //_subjectsService = new ObservableCollection<Subject>(_subjectsService.GetSubjects());
            enrollmentsDataGrid.ItemsSource = _enrollments;
            studentsDataGrid.ItemsSource = _students;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var subjects = _subjectsService.GetSubjects();
            var students = _studentsService.GetStudents();
            var enrollment = new Enrollment();

            new EnrollmentModal(students, subjects, enrollment).ShowDialog();

            if (enrollment.StudentId > 0)
            {
                var createdEnrollment = _dbService.CreateEnrollment(enrollment);

                _enrollments.Insert(0, createdEnrollment);
            }
        }

        private void enrollmentsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void studentsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
