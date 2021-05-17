using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Step;

namespace WebApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<CombSortStep> combSortSteps { get; set; }
        public DbSet<QuickSortingStep> quickSortingSteps { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CombSortStep>().ToTable("CombSortStep");
            modelBuilder.Entity<QuickSortingStep>().ToTable("QuickSortingStep");

        }
    }
}
