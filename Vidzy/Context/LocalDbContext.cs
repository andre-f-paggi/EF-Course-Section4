using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
