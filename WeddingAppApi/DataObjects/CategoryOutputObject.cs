using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAppApi.Models;

namespace WeddingAppApi.DataObjects
{
    public class CategoryOutputObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }
        public List<Spending> Spendings { get; set; }
    }
}