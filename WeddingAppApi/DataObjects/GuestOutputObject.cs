using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAppApi.Models;

namespace WeddingAppApi.DataObjects
{
    public class GuestOutputObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public GuestResponse Resonse { get; set; }
        public string Diet { get; set; }
        public string Side { get; set; }
        public string Comment { get; set; }
        public bool Editdiet { get; set; }
        public bool Editcomment { get; set; }

    }
}