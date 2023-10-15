using Lesson11.Models;
using Lesson11.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace Lesson11.Views
{
    /// <summary>
    /// Interaction logic for EnrollmentModal.xaml
    /// </summary>
    public partial class EnrollmentModal : Window
    {
        private Enrollment Enrollment;
        private EnrollmentDbService EnrollmentDbService;

        public EnrollmentModal()
        {
            InitializeComponent();
        }

        public EnrollmentModal(List<Student> students, List<Subject> subjects, Enrollment enrollment)
            : this()
        {
            studentsCombobox.ItemsSource = students;
            subjectsCombobox.ItemsSource = subjects;
            Enrollment = enrollment;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Enrollment enr = null;
            var result = MessageBox.Show("Do you want to create Enrollment?", "Confirm action", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
               var enrl = new Enrollment()
                {
                    StudentId = ((Student)studentsCombobox.SelectedItem).Id,
                    SubjectId = ((Subject)subjectsCombobox.SelectedItem).Id,
                    StartDate = startDate.SelectedDate ?? DateTime.Now,
                    EndDate = endDate.SelectedDate ?? DateTime.Now,
                };
                enr = enrl;
            }

            EnrollmentDbService.CreateEnrollment(enr);
        }
    }
}
