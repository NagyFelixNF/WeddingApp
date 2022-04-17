using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingAppApi.DataObjects
{
    public class EventOutputObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
    }
}