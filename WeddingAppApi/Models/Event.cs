using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        public string Title { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }          

    }
}