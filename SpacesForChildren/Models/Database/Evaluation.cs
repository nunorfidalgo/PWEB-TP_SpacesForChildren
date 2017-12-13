using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models.Database
{
    [Table("Evaluation")]
    public partial class Evaluation
    {
        public int EvaluationId { get; set; }

        [Required]
        public decimal StarGrade { get; set; } // star system like amazon

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? RegistryDateTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}