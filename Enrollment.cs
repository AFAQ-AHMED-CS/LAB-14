using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirst.Models{
    public enum Grades{
        A, B, C, D, F
    }
    public class Enrollment{
        public int Enrollment_ID { get; set; }
        public int Course_ID { get; set; }
        public int Student_ID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}