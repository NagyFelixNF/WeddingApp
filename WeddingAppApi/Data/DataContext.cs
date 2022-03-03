using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingAppApi.Models;

namespace WeddingAppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<SubPreparation> SubPreparations { get; set; }
    }
}