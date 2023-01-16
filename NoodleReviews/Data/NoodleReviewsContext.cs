using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoodleReviews.Models;

namespace NoodleReviews.Data
{
    public class NoodleReviewsContext : DbContext
    {
        public NoodleReviewsContext (DbContextOptions<NoodleReviewsContext> options)
            : base(options)
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        public DbSet<NoodleReviews.Models.NoodlePack> NoodlePack { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<NoodlePack>()
                .Property(e => e.Grade)
                .HasConversion<string>();
                
        }

        public override void Dispose()
        {
            Database.CloseConnection();
            base.Dispose();
        }
    }
}
