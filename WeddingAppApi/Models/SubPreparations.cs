using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class SubPreparation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        [ForeignKey("Preparation")]
        public int PreparationId { get; set; }
        public Preparation Preparation { get; set; }
    }
}