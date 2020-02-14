using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    [Table("Project")]
   public class Project
    {
        [Key]//set primary key
        public int ProjectId { get; set; }
        [Required]
        [StringLength(30)]
        public string ProjectName { get; set; }
        [Column(TypeName="Date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName="Date")]
        public DateTime? EndDate { get; set; }
        
        public IEnumerable<Employee>Employees{get;set;}
    }
}
