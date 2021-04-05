using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Data
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string Post { get; set; }
        public DateTime DateStarted { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
