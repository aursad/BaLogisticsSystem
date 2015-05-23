using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using BaLogisticsSystem.Infrastructure;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.DAL
{
    public class BaLogisticsSystemContext : DbContext
    {
        public BaLogisticsSystemContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}