using GeekBrains.SD.Lesson5.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace GeekBrains.SD.Lesson5.DAL
{
    public class StudentContext : DbContext
    {
        public DbSet<Students> Student { get; set; }

        static StudentContext()
        {
            Database.SetInitializer<StudentContext>(new DropCreateDatabaseAlways<StudentContext>());
        }

        public ObjectResult<T> ExecuteStoreQuery<T>(string commandText, params
        object[] paramenters)
        {
            return ObjectContext.ExecuteStoreQuery<T>(commandText, paramenters);
        }

        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(GetStudentsConfig());
        }
        private static EntityTypeConfiguration<Students> GetStudentsConfig()
        {
            var config = new EntityTypeConfiguration<Students>();
            config.Property(e => e.Age);
            config.Property(e => e.FirstName).HasMaxLength(256).IsRequired();
            config.Property(e => e.LastName).HasMaxLength(256);
            return config;
        }


    }
}
