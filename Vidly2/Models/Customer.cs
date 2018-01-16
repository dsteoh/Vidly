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
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; } //Navigation property
        public byte MembershipTypeId { get; set; } //Entity Framework will recong this and tread this as forign key
    }
}