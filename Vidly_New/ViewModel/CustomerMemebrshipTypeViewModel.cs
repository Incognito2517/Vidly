using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly_New.Models;

namespace Vidly_New.ViewModel
{
    public class CustomerMemebrshipTypeViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}