using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HawksStartApp.Models
{
    public class HawkaContext : DbContext
    {
        public HawkaContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<HawkaContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantCorpuse>().HasKey(rc => new { rc.CorpuseId, rc.RestaurantId });
        }

        public DbSet<Corpuse> Corpuses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantCorpuse> RestaurantCorpuses { get; set; }
    }
}