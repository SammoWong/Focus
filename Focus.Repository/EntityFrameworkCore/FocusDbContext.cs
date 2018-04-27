using Focus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Focus.Repository.EntityFrameworkCore
{
    public class FocusDbContext : DbContext
    {
        public FocusDbContext(DbContextOptions<FocusDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Organization> Organization { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<Module> Module { get; set; }

        public DbSet<Button> Button { get; set; }

        public DbSet<Permission> Permission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = System.Reflection.Assembly.GetExecutingAssembly()
                                          .GetTypes()
                                          .Where(type => !string.IsNullOrEmpty(type.Name))
                                          .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
