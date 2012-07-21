using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage="Please enter a valid email addresss")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select whether you're coming or not")]
        public bool? WillAttend { get; set; }
    }
}