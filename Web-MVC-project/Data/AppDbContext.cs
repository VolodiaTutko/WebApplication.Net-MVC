using Microsoft.EntityFrameworkCore;
using Web_MVC_project.Models;

namespace Web_MVC_project.Data
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ categoryID = 1, categoryName = "Croissants", displayOrder = 1 },
                new Category { categoryID = 2, categoryName = "Cakes", displayOrder = 2 },
                new Category { categoryID = 3, categoryName = "Eclairs", displayOrder = 3});
        }



    }
}
