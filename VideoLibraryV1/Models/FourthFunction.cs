using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibraryV1.Models
{
    public class FourthFunction
    {
        public DVDDetail DVDDetail { get; set; }
        public IEnumerable<ProducerDetail> ProducerDetails { get; set; }
        public IEnumerable<CastDetail> CastDetails { get; set; }
    }
}
