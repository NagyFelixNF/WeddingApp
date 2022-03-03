using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingAppApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt { get; set; }
        [ForeignKey("Wedding")]
        public int WeddingId {get; set;}
        public Wedding Wedding {get; set;}    
    }
}