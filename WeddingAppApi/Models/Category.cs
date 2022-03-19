using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeddingAppApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        [ForeignKey("Budget")]
        [JsonIgnore]
        public int BudgetId { get; set; }
        [JsonIgnore]
        public Budget Budget { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public int Total { get; set; }
        public List<Spending> Spendings { get; set; }
    }
}