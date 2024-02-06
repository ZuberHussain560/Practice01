using LoginAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.APIContext
{
    public class LoginContext:DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> option):base(option) { }
        
        public DbSet<User> Users { get; set; }
    }
}
