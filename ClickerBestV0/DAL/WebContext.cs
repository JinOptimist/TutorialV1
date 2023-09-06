using ClickerBestV0.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClickerBestV0.DAL
{
    public class WebContext : IdentityDbContext<User>
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }
    }
}
