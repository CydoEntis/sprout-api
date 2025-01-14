using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Models;

namespace TaskGarden.Data;

public class AppDbContext : IdentityDbContext<User> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}