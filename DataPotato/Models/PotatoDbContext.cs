using Microsoft.EntityFrameworkCore;
using MVCpotato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPotato.Models
{
    public class PotatoDbContext : DbContext
    {
        public PotatoDbContext()
        {
        }
        public PotatoDbContext(DbContextOptions<PotatoDbContext> options) : base(options) { }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DII2Q16\\SQLEXPRESS;Database=PotatoDB;Trusted_Connection=True;TrustServerCertificate=True");
        }


    }
}
