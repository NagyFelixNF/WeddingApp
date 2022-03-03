using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAppApi.Models;

namespace WeddingAppApi.DataObjects
{
    public class MainPreparationInputObject
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
        public List<SubPreparation> SubPreparations { get; set; }

    }
}