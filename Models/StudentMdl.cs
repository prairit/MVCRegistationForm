using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForm.Models
{
    public class StudentMdl
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}