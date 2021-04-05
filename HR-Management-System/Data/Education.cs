using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Data
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string Institution { get; set; }
        public DateTime DateStarted { get; set; }
        [ForeignKey("QualificationId")]
        public Qualification Qualification { get; set; }
        public int QualificationId { get; set; }
    }
}
