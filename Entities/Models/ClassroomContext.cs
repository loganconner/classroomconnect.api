using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClassroomContext : DbContext
    {
        public ClassroomContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Child>()
            .Property(b => b.Allergies)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<ChildAllergy>>(v));

            base.OnModelCreating(builder);
        }

        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        {

        }
        public DbSet<Child> Child { get; set; }

        public DbSet<Guardian> Guardian { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Phone> Phone { get; set; }

        public DbSet<PersonPhone> PersonPhone { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<PersonAddress> PersonAddress { get; set; }

        public DbSet<Allergy> Allergy { get; set; }

        public DbSet<ChildAllergy> ChildAllergy { get; set; }

        public DbSet<Classroom> Classroom { get; set; }

        public DbSet<Family> Family { get; set; }

    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassroomContext>
    //{
    //    public ClassroomContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../ClassroomConnect.Web/appsettings.json").Build();
    //        var builder = new DbContextOptionsBuilder<ClassroomContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new ClassroomContext(builder.Options);
    //    }
    //}


}
