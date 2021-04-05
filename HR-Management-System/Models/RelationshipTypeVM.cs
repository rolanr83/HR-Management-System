using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_System.Models
{
    public class RelationshipTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
