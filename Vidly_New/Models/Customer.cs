using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly_New.Models;

namespace Vidly.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Plese enter customer's name")]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display (Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display (Name= "Date of Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}