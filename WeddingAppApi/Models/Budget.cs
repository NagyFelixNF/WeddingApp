using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeddingAppApi.Models
{
    public class Budget
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        [JsonIgnore]
        public int WeddingId { get; set; }
        [JsonIgnore]
        public Wedding Wedding { get; set; }
        public int budget {get; set;}
        public List<Category> Categories { get; set; }

    }
}