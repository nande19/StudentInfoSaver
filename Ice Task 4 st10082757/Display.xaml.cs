using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ice_Task_4_st10082757
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        private List<variables> DataofStudents = new List<variables>();
       Saver saves = new Saver();
        public Display()
        {
            InitializeComponent();
           // ReadDataFromFile();
            //PopulateComboBox();
            LoadDataInBackground();

        }

        private async void LoadDataInBackground()
        {
            await Task.Run(() => ReadDataFromFile());
            PopulateComboBox();
        }                    variables studentData = null;


        public void ReadDataFromFile()
        {
            string fileName = "studentsInfo.txt";

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    //variables studentData = null;

                     while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Student Number: "))
                        {
                            studentData = new variables();
                            studentData.student = line.Substring("Student Number: ".Length);
                            //studentNumBox.Items.Add(studentData.student.ToString());
                        }
                        else if (line.StartsWith("Module Code: "))
                        {
                            studentData.Code = line.Substring("Module Code: ".Length);
                        }
                        else if (line.StartsWith("Mark: "))
                        {
                            studentData.Mark = line.Substring("Mark: ".Length);
                        }
                        else if (line.StartsWith("Date: "))
                        {
                            // Assuming the date format in the file is "yyyy-MM-dd"
                            string dateInString = line.Substring("Date: ".Length);
                            DateTime Date;
                            DateTime.TryParse(dateInString, out Date);
                            studentData.date = Date;
                            DataofStudents.Add(studentData);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void PopulateComboBox()
        {
            studentNumBox.ItemsSource = DataofStudents.Select(s => s.student).ToList();

                   }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedStudent = studentNumBox.SelectedItem as string;

            if (selectedStudent == null)
            {
                MessageBox.Show("Please select a student number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedStudentData = DataofStudents.Where(s => s.student == selectedStudent).ToList();

            if (selectedStudentData.Any())
            {
                //MAKE CHANGES HERE 
                studentInfo.ItemsSource = selectedStudentData;
            }
            else
            {
                MessageBox.Show($"Student with number {selectedStudent} not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void display_Click(object sender, RoutedEventArgs e)
        {
            studentInfo.ItemsSource = DataofStudents;

            /*
                        //check the selected student number from the combo box 
                        string selected = studentNumBox.SelectedItem as string;
                        foreach (variables val in DataofStudents)
                        {
                            if (val.student == selected)
                            {
                            }

                        }
                    }
            */
        }

        private void btnBackToMain(object sender, RoutedEventArgs e)
        {

            saves.Show();    
        }
        private void btnHome(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
        }
    }
}
