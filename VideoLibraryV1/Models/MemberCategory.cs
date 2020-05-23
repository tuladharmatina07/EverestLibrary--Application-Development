using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class MemberCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int TotalLoanAmount { get; set; }
        [Required]
        public DateTime ReturningDate { get; set; }
        [Required]
        public int FineAmountPerDay { get; set; }
        public virtual IEnumerable<MemberDetail> MemberDetails { get; set; }
    }
}