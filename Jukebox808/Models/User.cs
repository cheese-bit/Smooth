using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jukebox808.Models
{
    public class User
    {

        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Mow Day")]
        public DayOfWeek? MowDay { get; set; }
        [Display(Name = "Team")]
        public int Team { get; set; }

        [Display(Name = "One-Time Extra Mow Day")]
        public DayOfWeek? ExtraMowDay { get; set; }
        //[datatype(datatype.date)]
        //[displayformat(dataformatstring = "{0:mm-dd-yyyy}", applyformatineditmode = true)]
        //public datetime? extramowday { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Display(Name = "State")]

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        //[RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }

        [Display(Name = "Suspend Services Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Suspend Services End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Balance")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Display(Name = "Services Confirmation Date")]
        [DataType(DataType.Date)]
        public DateTime? ServicesConfirmationDate { get; set; }

        [Display(Name = "One-Time Services Confirmation")]
        [DataType(DataType.Date)]
        public DateTime? ExtraServicesDayConfirmation { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
