using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<DataQuickSorting> dataQuickSortings { get; set; }
        public DbSet<DataCombSort> dataCombSorts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DataQuickSorting>().ToTable("DataQuickSorting");

            modelBuilder.Entity<DataCombSort>().ToTable("DataCombSort");

        }
    }
}
