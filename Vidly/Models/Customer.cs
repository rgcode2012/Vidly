using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Customer's Name.")]
        [StringLength(255)]     
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Bithdate { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage ="Please select Membership type.")]
        public byte MembershipTypeId { get; set; }


    }
}