using Microsoft.AspNetCore.Mvc;
using StockControl.Data;

namespace StockControl.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}
