using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeddingAppApi.Models
{
    public class Wedding
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public List<Preparation> Preparations { get; set; }
        public Budget Budget { get; set; }
        public Seating Seating { get; set; }
        public List<Guest> Guests { get; set; }
    }
}