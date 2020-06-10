using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models{
    public class Course{
        public int Course_ID { get; set; }
        public string Title { get; set; }
        public int Credits_Hours{ get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}