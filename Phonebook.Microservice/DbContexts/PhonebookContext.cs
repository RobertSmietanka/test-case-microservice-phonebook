using Microsoft.EntityFrameworkCore;
using Phonebook.Microservice.Entities;
using Phonebook.Microservice.Entities.Mappings;

namespace Phonebook.Microservice.DbContexts
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AddressPoint> AddressPoints { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = new AddressPointMap(modelBuilder.Entity<AddressPoint>());
        }
    }
}
