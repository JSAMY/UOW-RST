using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using Restaurant.Common;

namespace Restaurant.Web.Models
{
    public class RestaurantViewModel
    {
        [Required()]
        //[RegularExpression(@"/^[a-zA-Z\s]+$/", ErrorMessage = "Not a valid name")]
        //[RegularExpression(@"[^a-zA-Z\s]", ErrorMessage = "Not a valid name")]
        [Display(Name = "Your name:")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Your email:")]        
        public string Email { get; set; }

        [RSTCryptography(Mode = Mode.Encryption)]
        [Required]
        [Phone(ErrorMessage = "Not a valid Phone number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [RegularExpression(@"^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Your phone number:")]
        public string PhoneNum { get; set; }

        [Required]        
        [Display(Name = "Preferred date/time:")]
        public DateTime PreferredDateTime { get; set; }
    }
}