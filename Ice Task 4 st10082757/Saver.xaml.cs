using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Validation;

namespace Ice_Task_4_st10082757
{
    /// <summary>
    /// Interaction logic for Saver.xaml
    /// </summary>
    public partial class Saver : Window
    {
        public Saver()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Today;
            datePicker.SelectedDateChanged += DatePicker_SelectedDateChanged; // Add event handler

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if the selected date is after today
            if (datePicker.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("Please select a date that is not in the future.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                datePicker.SelectedDate = DateTime.Today; // Set it back to today's date
            }
        }


        public void Saving(object sender, RoutedEventArgs e)
        {

            while (true)
            {
                string studentNum = txtStudentNum.Text;
                string moduleCode = txtModuleCode.Text;
                string yearMark = txtMark.Text;

                DateTime date;



                if (!Validations.IsStudentNumberValid(studentNum))
                {
                    MessageBox.Show("Invalid module code format. Please use the format 'ST12345678'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; //Retry the operation
                }

                // Validate the module code
                if (!Validations.IsValidModuleCode(moduleCode))
                {
                    MessageBox.Show("Invalid module code format. Please use the format 'CLDV6212'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Retry the operation
                }

                // Validate the mark
                if (!Validations.IsValidYearMark(yearMark))
                {
                    MessageBox.Show("Invalid mark. Please enter a valid integer for the mark.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Retry the operation
                }
                string dateString = datePicker.SelectedDate?.ToString("yyyy-MM-dd");
                if (!Validations.IsDateFormatValid(dateString))
                {
                    MessageBox.Show("Invalid date format. Please use the format 'yyyy-MM-dd'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    date = datePicker.SelectedDate.Value;
                }

                // Validate the mark
                if (!Validations.IsValidYearMark(yearMark))
                {
                    MessageBox.Show("Invalid mark. Please enter a valid integer for the mark.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Retry the operation
                }

                variables vary = new variables();
                vary.student = studentNum;
                vary.Code = moduleCode;
                vary.Mark = yearMark;
                vary.date = date;

                string fileName = "studentsInfo.txt";
                try
                {
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine($"Student Number: {vary.student}");
                        writer.WriteLine($"Module Code: {vary.Code}");
                        writer.WriteLine($"Mark: {vary.Mark}");
                        writer.WriteLine($"Date: {vary.date}");
                        writer.WriteLine(new string('-', 30)); // Separator line
                    }
                    txtStudentNum.Clear();
                    txtModuleCode.Clear();
                    txtMark.Clear();
                    //txtRegDate.Clear();

                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    break; // Exit the loop when data is successfully saved
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Retry the operation
                }

            }

            if (string.IsNullOrWhiteSpace(txtStudentNum.Text) ||
                            string.IsNullOrWhiteSpace(txtModuleCode.Text) ||
                            string.IsNullOrWhiteSpace(txtMark.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btnNext(object sender, RoutedEventArgs e)
        {
              (new Display()).Show();
                this.Close();

        }

        private void btnHome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
        }
    }
}
