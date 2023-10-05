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
        public MainWindow()
        {
            InitializeComponent();

            _enrollments = new ObservableCollection<Enrollment>();
            _dbService = new EnrollmentDbService();
            _subjectsService = new SubjectsDbService();
            _studentsService = new StudentDbService();

            LoadData();
        }

        private void LoadData()
        {
            _enrollments.Clear();
            _enrollments = new ObservableCollection<Enrollment>(_dbService.GetActiveEnrollments());
            enrollmentsDataGrid.ItemsSource = _enrollments;


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
    }
}
