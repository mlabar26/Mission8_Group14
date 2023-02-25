using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Group14.Models
{
    public class TaskForm
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Must Enter the Task Name.")]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Need to Enter the Quadrant.")]
        public int Quadrant { get; set; }

        public bool Completed { get; set; }


        // foreign key relationship
        public int? CategoryId { get; set; } // foreign key
        public Category Category { get; set; } // instance of object

    }
}
