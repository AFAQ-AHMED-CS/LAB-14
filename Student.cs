using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models{
    public class Student{
		
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int ID { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}