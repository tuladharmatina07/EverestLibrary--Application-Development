using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class CastMember
    {
        [Key]
        public int Id { get; set; }
        public int DVDDetailId { get; set; }
        public int CastDetailId { get; set; }


        [ForeignKey("DVDDetailId")]
        public virtual DVDDetail DVDDetails { get; set; }
        [ForeignKey("CastDetailId")]
        public virtual CastDetail CastDetails { get; set; }
    }
}