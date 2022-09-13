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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        Demo_PRN221Context context = new Demo_PRN221Context();
        private int id;

        public UpdateWindow(int sId)
        {
            InitializeComponent();
            Student s = context.Students.Single(s => s.Id == sId);
            id = s.Id;
            txtName.Text = s.Name;
            dpDob.Text = s.Dob.ToString();
            cbMajor.Text = s.Major;
            if(s.Sex.Equals("Male"))
            {
                rbMale.IsChecked = true;
                rbFemale.IsChecked = false;
            }
            else
            {
                rbMale.IsChecked = false;
                rbFemale.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student st = context.Students.Single(s => s.Id == id);
            st.Name = txtName.Text;
            st.Dob = DateTime.Parse(dpDob.Text);
            st.Major = cbMajor.Text;
            st.Sex = rbMale.IsChecked.Value ? "Male" : "Female";

            context.SaveChanges();

            this.Close();
        }
    }
}
