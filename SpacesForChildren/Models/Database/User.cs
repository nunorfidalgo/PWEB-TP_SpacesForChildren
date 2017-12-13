using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models.Database
{
    [Table("User")]
    public partial class User
    {
        public int UserId { get; set; }

        //[ForeignKey("Children")]
        //public int ChildrenId { get; set; }

        public int BI { get; set; }
        public int NIF { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? RegistryDateTime { get; set; }

        public UserType? UserType { get; set; }

        public virtual ICollection<Children> Childrens { get; set; }
    }
}