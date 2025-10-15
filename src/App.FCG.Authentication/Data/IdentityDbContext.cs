using Microsoft.EntityFrameworkCore;

namespace FCG.Authentication.Data
{
    public class IdentityDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base (options)
        {
            
        }
    }
}
