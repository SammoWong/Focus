using Focus.Domain.Entities;
using Focus.Domain.Entities.Configurations;
using Focus.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain
{
    public class FocusDbContext : DbContext
    {
        public FocusDbContext()
        {
            //Database.Migrate();
        }

        //public FocusDbContext(DbContextOptions<FocusDbContext> options) : base()
        //{
        //    Database.EnsureCreated();
        //}

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Button> Buttons { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<DictionaryType> DictionaryTypes { get; set; }

        public DbSet<DictionaryDetail> DictionaryDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var typesToRegister = System.Reflection.Assembly.GetExecutingAssembly()
            //                              .GetTypes()
            //                              .Where(type => !string.IsNullOrEmpty(type.Name))
            //                              .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.ApplyConfiguration(configurationInstance);
            //}
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new ButtonConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new DictionaryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DictionaryDetailConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSetting.SqlConnectionString);
            }
        }
    }
}
