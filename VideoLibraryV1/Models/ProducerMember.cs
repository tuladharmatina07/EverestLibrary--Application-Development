using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class ProducerMember
    {
        [Key]
        public int Id { get; set; }
        public int DVDDetailId { get; set; }
        public int ProducerDetailId { get; set; }


        [ForeignKey("DVDDetailId")]
        public virtual DVDDetail DVDDetails { get; set; }
        [ForeignKey("ProducerDetailId")]
        public virtual ProducerDetail ProducerDetails { get; set; }
    }
}