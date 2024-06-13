using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzelDersApp.Data.Concrete.EfCore.Config;
using OzelDersApp.Data.Concrete.EfCore.Extensions;
using OzelDersApp.Entity.Concrete;
using OzelDersApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Data.Concrete.EfCore.Context
{
    public class OzelDersContext : IdentityDbContext<User, Role, string>
    {
        public OzelDersContext(DbContextOptions options) : base(options)
        {
        }
    
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<TeacherBranch> TeachersBranches { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get;set; }
        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BranchConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
