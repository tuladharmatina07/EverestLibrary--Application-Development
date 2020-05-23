using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class Loan
    { 

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int FineAmount { get; set; }
        public int MemberDetailId { get; set; }
        public int DVDDetailId { get; set; }

        public int LoanTypeId { get; set; }
        [ForeignKey("MemberDetailId")]
        public virtual MemberDetail MemberDetails { get; set; }
        [ForeignKey("DVDDetailId")]
        public virtual DVDDetail DVDDetails { get; set; }
        [ForeignKey("LoanTypeId")]
        public virtual LoanType LoanTypes { get; set; }
    }
}