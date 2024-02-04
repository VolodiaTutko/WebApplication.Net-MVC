using Microsoft.EntityFrameworkCore;

namespace Web_MVC_project.Data
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
