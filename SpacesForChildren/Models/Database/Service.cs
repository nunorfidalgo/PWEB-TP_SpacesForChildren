using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models.Database
{
    [Table("Service")]
    public partial class Service
    {
        public int ServiceId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Type { get; set; } // tipo: creche, pre-escolar, ensino basico, tranporte de crianças, aulas de natação, aulas de ed. musical

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // entre idades
        public int AgeMinus { get; set; }
        public int AgeMajor { get; set; }

        // nivel de ensino
        public decimal EducationLevel { get; set; }

        // valor da mensalidade
        public float MonthlyPayment { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? RegistryDateTime { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Children> Childrens { get; set; }
    }
}