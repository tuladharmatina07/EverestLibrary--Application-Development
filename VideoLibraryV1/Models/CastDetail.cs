using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class CastDetail
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        
        public DateTime DateOfBirth { get; set; }

        public virtual IEnumerable<DVDDetail> DVDDetails { get; set; }
    }
}