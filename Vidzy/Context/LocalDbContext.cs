using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidzy.EntityConfigurations;
using Vidzy.Model;

namespace Vidzy.Context
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext() : base("LocalDbContext")
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
        }
    }
}
