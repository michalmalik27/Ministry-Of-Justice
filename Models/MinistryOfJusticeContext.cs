using Microsoft.EntityFrameworkCore;

namespace MinistryOfJustice.Models
{
    public class MinistryOfJusticeContext : DbContext
    {
        public MinistryOfJusticeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Association> Associations { get; set; }
        public DbSet<AssociationType> AssociationTypes { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssociationType>().HasData(new AssociationType
            {
                AssociationTypeId = 1,
                AssociationTypeName = "סוג 1",
            }, new AssociationType
            {
                AssociationTypeId = 2,
                AssociationTypeName = "סוג 2",
            }, new AssociationType
            {
                AssociationTypeId = 3,
                AssociationTypeName = "סוג 3",
            });

            modelBuilder.Entity<CurrencyType>().HasData(new CurrencyType
            {
                CurrencyTypeId = 1,
                CurrencyTypeName = "סוג 1",
            }, new CurrencyType
            {
                CurrencyTypeId = 2,
                CurrencyTypeName = "סוג 2",
            }, new CurrencyType
            {
                CurrencyTypeId = 3,
                CurrencyTypeName = "סוג 3",
            });

            modelBuilder.Entity<Association>().HasData(new Association
            {
                AssociationId = 1,
                Name = "עמותה 1",
                AssociationTypeId = 1,
                DonationAmount = 9000,
                DonationPurpose = "מטרה 1",
                CurrencyTypeId = 1,
                ConversionRate = 1.1m,
                DonationTerms = "חוקים",
                CreatedByUserId = 1
            },
            new Association
            {
                AssociationId = 2,
                Name = "עמותה 2",
                AssociationTypeId = 2,
                DonationAmount = 8000,
                DonationPurpose = "מטרה 2",
                CurrencyTypeId = 2,
                ConversionRate = 4.5m,
                DonationTerms = "חוקים", 
                CreatedByUserId = 2
            });
        }
    }
}
