using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class EducationVM
    {
        [Required]
        public string Institution { get; set; }
        public DateTime DateStarted { get; set; }
        public QualificationVM Qualification { get; set; }
        public int QualificationId { get; set; }

        public IEnumerable<SelectListItem> Qualifications { get; set; }
    }
}
