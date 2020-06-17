using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jukebox808.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jukebox808.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        {
         private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (user == null)
            {
                return View("Create");
            }
            else
            {
                return View("Details", user);
            }

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            User user = new User();
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(User);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,MowDay,Address,ZipCode,IdentityUserId,MowDay")] Customer customer)
        {
            //if (ModelState.IsValid)
            //{
            //if (customer.Id == 0)
            //{
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            customer.IdentityUserId = userId;
            _context.Customers.Add(customer);
            //}
            //else
            //{
            //    var customerInDB = _context.Customers.Single(m => m.Id == customer.Id);
            //    customerInDB.Name = customer.Name;
            //    customerInDB.Address = customer.Address;
            //    customerInDB.ZipCode = customer.ZipCode;
            //    customerInDB.MowDay = customer.MowDay;
            //}
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //return View("Index");
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(user);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MowDay,ExtraMowDay,Address,StartDate,EndDate,ZipCode")] Customer customer)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userInDB = _context.User.Single(m => m.Id == user.Id);
                    userInDB.Name = customer.Name;
                    userInDB.Address = customer.Address;
                    userInDB.ZipCode = customer.ZipCode;
                    userInDB.MowDay = customer.MowDay;
                    userInDB.ExtraMowDay = customer.ExtraMowDay;
                    userInDB.StartDate = customer.StartDate;
                    userInDB.EndDate = customer.EndDate;
                    //_context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = user.Id.ToString() });
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", User.IdentityUserId);
            return View(User.Id);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var User = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
    }
}