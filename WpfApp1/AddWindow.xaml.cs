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
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Demo_PRN221Context context = new Demo_PRN221Context();

        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student st = new Student();
            st.Name = txtName.Text;
            st.Dob = DateTime.Parse(dpDob.Text);
            st.Major = cbMajor.Text;
            st.Sex = rbMale.IsChecked.Value ? "Male" : "Female";

            context.Add(st);
            context.SaveChanges();

            this.Close();
        }
    }
}
