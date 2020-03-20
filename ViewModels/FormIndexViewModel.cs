using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace MVCRegistationForm.ViewModels
{
    public class FormIndexViewModel
    {
        public StudentDTO studentDto { get; set; }
        public IEnumerable<StudentDTO> ListStudentDto { get; set; }
    }
}