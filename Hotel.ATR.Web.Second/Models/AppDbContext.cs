using Microsoft.EntityFrameworkCore;

namespace Hotel.ATR.Web.Second.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }


    }
}
