using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace Restaurant.Web.Models
{
    public class RestaurantViewModel
    {
        [Required]
        [Display(Name = "Your name:")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Your email:")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Not a valid Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Your phone number:")]
        public string Number { get; set; }

        [Required]        
        [DataType(DataType.PhoneNumber)]        
        [Display(Name = "Preferred date/time:")]
        public DateTime PreferredDateTime { get; set; }
    }
}