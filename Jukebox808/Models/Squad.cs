using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mowerman.Models
{
    public class Squad
    {

        public int Id { get; set; }
        [Display(Name = "Team")]
        public int Team { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Zip Code")]
        //[RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public string ZipCode { get; set; }
        //[display(name = "team")]
        //public string team { get; set; }

        //[display(name = "job address")]
        //public string jobaddress { get; set; }
        //[display(name = "clock-in time")]
        //[datatype(datatype.date)]
        //[displayformat(dataformatstring = "{0:hh:mm}", applyformatineditmode = true)]
        //public datetime? clockin { get; set; }

        //[display(name = "clock-out time")]
        //[datatype(datatype.date)]
        //[displayformat(dataformatstring = "{0:hh:mm}", applyformatineditmode = true)]
        //public datetime? clockout { get; set; }

        //[display(name = "current date")]
        //[datatype(datatype.date)]
        //[displayformat(dataformatstring = "{0:mm-dd-yyyy}", applyformatineditmode = true)]
        //public datetime? date { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [NotMapped]
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Squad> Employees { get; set; }
    }
}
