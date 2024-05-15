using Microsoft.EntityFrameworkCore;
using SurpriseCalendarAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SurpriseCalendarAPI.Data
{
    public class SurpriseCalendarContext : DbContext
    {
        public SurpriseCalendarContext(DbContextOptions<SurpriseCalendarContext> options) : base(options) { }

        public DbSet<SurpriseCalendarSquare> SurpriseCalendar { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<SurpriseCalendarSquare>().HasKey(s => s.Id);
        //}
    }
}
