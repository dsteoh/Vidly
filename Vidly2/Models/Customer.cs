using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name")]
        [StringLength(250)]
        public string Name { get; set; }

        [Min18YearIfAMember]
        public DateTime? Dob { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //Navigation property

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //Entity Framework will recong this and tread this as forign key
    }
}