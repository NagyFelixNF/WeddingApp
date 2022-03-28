using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAppApi.Models;

namespace WeddingAppApi.DataObjects
{
    public class InvitationObject
    {
         public int Id { get; set; }
        public int Weddingid { get; set; }
        public int? Guestid { get; set; }
        public string Name { get; set; }
        public GuestResponse Response { get; set; }
        public string Diet { get; set; }
        public string Comment { get; set; }
        public string Action { get; set; }
    }
}