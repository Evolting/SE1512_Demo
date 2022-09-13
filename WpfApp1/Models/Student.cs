using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Major { get; set; }
        public string Sex { get; set; }
    }
}
