using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpacesForChildren.Models.Database
{
    [Table("Students")]
    public partial class Student : ApplicationUser
    {
        public int StudentId { get; set; }

        //[ForeignKey("AspNetUsers")]
        public virtual IdentityUser Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy:HH:mm}", ApplyFormatInEditMode = true)]
        public new DateTime? RegistryDateTime { get; set; }

        //public virtual ICollection<IdentityUser> IdentityUsers { get; set; }
    }

}