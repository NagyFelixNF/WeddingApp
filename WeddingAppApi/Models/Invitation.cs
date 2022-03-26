using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class Invitation
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        [ForeignKey("Guest")]
        public int? GuestId { get; set; }
        public  Guest Guest  { get; set; }
        public string Name { get; set; }
        public GuestResponse Response { get; set; }
        public string Diet { get; set; }
        public string Comment { get; set; }
    }
}