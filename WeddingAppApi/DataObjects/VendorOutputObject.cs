using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingAppApi.DataObjects
{
    public class VendorOutputObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public string Email { get; set; }    
        public string Telnumber { get; set; }    
        public string Customid { get; set; }    
        public bool Editable { get; set; }         
    }
}