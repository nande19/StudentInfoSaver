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

namespace Ice_Task_4_st10082757
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Saver saves = new Saver();
        Display shows = new Display();  
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Display(object sender, RoutedEventArgs e)
        {
            shows.Show();
            this.Close();
        }

        private void Saver(object sender, RoutedEventArgs e)
        {
            saves.Show();
            this.Close();
        }
    }
}
