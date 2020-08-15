using Microsoft.EntityFrameworkCore;
using Project_of_Online_Product_Management_System.Models;

namespace Project_of_Online_Product_Management_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderandComment> OrderandComments { get; set; }
        public DbSet<CommentTable> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>()
                .HasMany<Users>(u => u.Users)
                .WithOne(a => a.Actor);


        }
    }
}
