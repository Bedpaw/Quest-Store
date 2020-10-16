using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;

namespace QuestStore.Infrastructure.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BaseEntity)));

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }

            modelBuilder.Entity<Quest>().Property(q => q.Type).HasConversion<string>();
            modelBuilder.Entity<User>().HasDiscriminator<string>("Role").HasValue<User>("Admin");

            modelBuilder.SeedData();
        }

//#if DEBUG
//        //Constructor added for generating PowerTool diagrams.  
//        public StoreDbContext()
//        {
//        }
//        // Method Needed by PowerTool
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Db = Dummy");
//        }
//#endif

    }
}
