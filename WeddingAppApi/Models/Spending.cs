using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeddingAppApi.Models
{
    public class Spending
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        [JsonIgnore]
        public int CategoryId { get; set; }
        [JsonIgnore]   
        public Category Category { get; set; }
        public string Title { get; set; }
        public int? Cost { get; set; }
    }
}