using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public string Email { get; set; }    
        public string Telnumber { get; set; }    
        public string Customid { get; set; }    
        public bool Editable { get; set; }         
    }
}