using ClickerBestV0.DAL;
using ClickerBestV0.DAL.Models;
using ClickerBestV0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickerBestV0.Controllers
{
    public class HomeController : Controller
    {
        private WebContext _webContext;
        private UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager, WebContext webContext)
        {
            _userManager = userManager;
            _webContext = webContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var viewModel = new IndexViewModel()
            {
                Name = user.UserName,
                Exp = user.Exp,
                Coins = user.Money
            };

            return View(viewModel);
        }

        public IActionResult Learn()
        {
            var userDb = _webContext.Users.First(x => x.UserName == User.Identity.Name);
            userDb.Exp++;
            _webContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Job()
        {
            var userDb = _webContext.Users.First(x => x.UserName == User.Identity.Name);
            userDb.Money = userDb.Money + userDb.Exp;
            _webContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
