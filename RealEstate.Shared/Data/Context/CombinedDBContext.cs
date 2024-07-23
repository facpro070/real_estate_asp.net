using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Models.Entities.Users;
using RealEstate.Shared.Models.Entities.Clients;
using RealEstate.Shared.Models.Entities.Contracts;
using RealEstate.Shared.Models.Entities.Estates;
using RealEstate.Shared.Models.Entities.Listings;

namespace RealEstate.Shared.Data.Context
{
    public class CombinedDBContext : DbContext
    {
        public CombinedDBContext(DbContextOptions<CombinedDBContext> options) : base(options) { }

        // Users
        public virtual DbSet<UserEntity> UserEntities { get; set; }
        public virtual DbSet<UserAttribute> UserAttributes { get; set; }
        public virtual DbSet<UserGroupMembership> UserGroupMemberships { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<UsernameLoginFailure> UsernameLoginFailures { get; set; }

        // Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        // Contracts
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contract_Invoice> Contract_Invoices { get; set; }
        public DbSet<Contract_Type> Contract_Type { get; set; }
        public DbSet<Payment_Frequency> Payment_Frequencies { get; set; }
        public DbSet<Under_Contract> Under_Contracts { get; set; }

        // Estates
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Estate_Status> Estate_Statuses { get; set; }
        public DbSet<In_Charge> In_Charges { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Listings
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ListingStats> ListingStats { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=realestate;User Id=realestateuser;Password=password;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            // Users
            ConfigureUserEntities(modelBuilder);

            // Clients
            ConfigureClientEntities(modelBuilder);

            // Contracts
            ConfigureContractEntities(modelBuilder);

            // Estates
            ConfigureEstateEntities(modelBuilder);

            // Listings
            ConfigureListingEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureUserEntities(ModelBuilder modelBuilder)
        {
            // User entity configurations (from UsersDBContext)
            // ... (include all the entity configurations for UserEntity, UserAttribute, etc.)
        }

        private void ConfigureClientEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(c => c.Id).IsUnique();

            modelBuilder
                .Entity<Contact>()
                .HasOne(cl => cl.Client)
                .WithOne(c => c.Contact)
                .HasForeignKey<Client>(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Client>()
               .HasOne(c => c.Contact)
               .WithOne(cl => cl.Client)
               .HasForeignKey<Contact>(cl => cl.Contact_Details)
               .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureContractEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract_Invoice>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Contract_Type>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Payment_Frequency>().HasIndex(ci => ci.Id).IsUnique();
            modelBuilder.Entity<Under_Contract>().HasIndex(ci => ci.Id).IsUnique();

            modelBuilder
                .Entity<Contract>()
                .HasOne(cl => cl.Client)
                .WithMany(c => c.Contracts)
                .HasForeignKey(cl => cl.Client_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(cl => cl.Contact)
                .WithOne(c => c.Client)
                .HasForeignKey<Contact>(c => c.Client_Id);
        }

        private void ConfigureEstateEntities(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Estate>()
                .HasOne(cl => cl.City)
                .WithMany(c => c.Estates)
                .HasForeignKey(cl => cl.City_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(cl => cl.Cities)
                .HasForeignKey(c => c.Country_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<PriceHistory>()
                .Ignore(ph => ph.OffersHistoryTouples);

            modelBuilder
               .Entity<Listing>()
               .HasOne(c => c.PriceHistory)
               .WithOne(cl => cl.Listing)
               .HasForeignKey<PriceHistory>(cl => cl.Listing_Id)
               .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureListingEntities(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .HasOne(cl => cl.Company)
                .WithMany(cl => cl.Employees)
                .HasForeignKey(cl => cl.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
               .Entity<Contact>()
               .HasOne(co => co.Client)
               .WithOne(cl => cl.Contact)
               .HasForeignKey<Contact>(co => co.Client_Id)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}