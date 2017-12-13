using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models.Database
{
    [Table("Children")]
    public partial class Children
    { 
        public int ChildrenId { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? RegistryDateTime { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}