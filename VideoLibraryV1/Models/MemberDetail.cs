using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class MemberDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int MemberCategoryId { get; set; }


        [ForeignKey("MemberCategoryId")]
        public virtual MemberCategory MemberCategories { get; set; }


        public virtual IEnumerable<Loan> Loans { get; set; }
    }
}