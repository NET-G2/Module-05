using Lesson11.Services;
using System.Windows;

namespace Lesson11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EnrollmentDbService _dbService;
        public MainWindow()
        {
            InitializeComponent();

            _dbService = new EnrollmentDbService();

            LoadData();
        }

        private void LoadData()
        {
            enrollmentsDataGrid.ItemsSource = _dbService.GetActiveEnrollments();
        }
    }
}
