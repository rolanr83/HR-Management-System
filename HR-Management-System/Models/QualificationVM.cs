﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class QualificationVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Date Completed")]
        public DateTime DateCompleted { get; set; }
    }
}
