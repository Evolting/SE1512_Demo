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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Demo_PRN221Context context = new Demo_PRN221Context();

        public void Reload()
        {
            context = new Demo_PRN221Context();
            dgStudent.ItemsSource = context.Students.ToArray();
        }

        public MainWindow()
        {
            InitializeComponent();
            dgStudent.ItemsSource = context.Students.ToArray();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow fAdd = new AddWindow();
            fAdd.ShowDialog();

            Reload();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Student s = (Student) dgStudent.SelectedItem;
            UpdateWindow fUpdate = new UpdateWindow(s.Id);
            fUpdate.ShowDialog();

            Reload();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Student s = (Student)dgStudent.SelectedItem;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Remove(s);
                context.SaveChanges();
            }

            Reload();
        }
    }
}
