using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class DVDDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DVDName { get; set; }
        public string StudioName { get; set; }
        public DateTime ReleasedDate { get; set; }
        public Boolean AgeRestriction { get; set; }
        public int Length { get; set; }
        [NotMapped]
        public HttpPostedFile CoverImage { get; set; }
        public string CoverImagePath { get; set; }

        public virtual IEnumerable<Loan> Loans { get; set; }
        
    }
}