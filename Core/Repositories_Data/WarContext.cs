using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Repositories_Data
{
    public class WarContext:DbContext
    {
        public WarContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<TypeBuilding> TypesBuildings { get; set; }
        
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   => optionsBuilder.UseSqlServer("Server=DESKTOP-R5RADSP;Database=WarProject;Trusted_Connection=True;TrustServerCertificate=True");
*/
        
}
}
