using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingAppApi.Models
{
    public class Preparation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        public List<SubPreparation> SubPreparations { get; set; }
    }
}