using FA_1.Data;
using FA_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA_1.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public ActionResult Index()
        {
            return View(_context.StaffMembers.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.StaffMembers.Find(id));
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.StaffMembers.Add(staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.StaffMembers.Find(id));
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.StaffMembers.Update(staff);
                    _context.SaveChanges();
                }
                catch
                {
                    return View(staff);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staff/Delete/5 (Added GET Action)
        public ActionResult Delete(int id)
        {
            var staff = _context.StaffMembers.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff); 
        }

        // POST: Staff/DeleteConfirmed/5 (Renamed to DeleteConfirmed)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var staff = _context.StaffMembers.Find(id);
            if (staff != null)
            {
                _context.StaffMembers.Remove(staff);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}