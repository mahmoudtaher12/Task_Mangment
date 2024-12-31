using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Yassinmohammed_w2_0523057.Models.Entites;

namespace Yassinmohammed_w2_0523057.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne(x => x.Projects)
                .WithMany(r => r.Tasks)
                .HasForeignKey(y => y.projectId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tasks>()
                .HasOne(v => v.TeamMembers)
                .WithMany(c => c.Tasks)
                .HasForeignKey(y => y.TeamMemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
