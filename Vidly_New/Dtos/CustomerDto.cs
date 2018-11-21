using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_New.Models;

namespace Vidly_New.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Plese enter customer's name")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}