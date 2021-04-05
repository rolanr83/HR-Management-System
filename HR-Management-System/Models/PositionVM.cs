using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class PositionVM
    {
        [Required]
        public string Post { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        public DepartmentVM Department { get; set; }
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
