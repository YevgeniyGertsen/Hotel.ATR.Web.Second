using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//NuGet\Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 8.0.0

namespace Hotel.ATR.Web.Second.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
            : base(options) { }
    }

}
