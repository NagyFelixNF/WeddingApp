using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class Seating
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        public Byte[] layoutjson { get; set; }
    }
}