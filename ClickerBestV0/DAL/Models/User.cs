using Microsoft.AspNetCore.Identity;

namespace ClickerBestV0.DAL.Models
{
    public class User : IdentityUser
    {
        public int Exp { get; set; }

        public int Money { get; set; }
    }
}
