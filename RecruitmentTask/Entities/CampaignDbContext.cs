using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Models;

namespace RecruitmentTask.Entities
{
    public class CampaignDbContext : DbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<EmeraldAccount> EmeraldAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("decimal(18,2)");
                }
            }
        }
    }
}
