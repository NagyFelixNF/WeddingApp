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
        public DbSet<Budget> Budget { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Seating> Seating { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}