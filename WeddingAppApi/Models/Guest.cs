using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingAppApi.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }
        public  Wedding Wedding  { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public GuestResponse Response { get; set; }
        public string Diet { get; set; }
        public string Side { get; set; }
        public string Comment { get; set; }

    }

    public enum GuestResponse
    {
        Unknown,
        Pending,
        OnlyCeremony,
        OnlyReception,
        Canceled,
        AcceptedBoth
    }
}