﻿using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Infrastructure.Data.Seed;

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

            var entitiesTypes = Assembly.GetAssembly(typeof(BaseEntity))
                ?.GetTypes()
                .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BaseEntity)));

            if (entitiesTypes != null)
            {
                foreach (var type in entitiesTypes)
                {
                    modelBuilder.Entity(type);
                }
            }

            modelBuilder.Entity<Quest>().Property(q => q.Type).HasConversion<string>();
            modelBuilder.Entity<User>().HasDiscriminator<string>("Role").HasValue<User>("Admin");

            modelBuilder.Seed();
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
