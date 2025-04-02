using FA_1.Data;
using FA_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq; 

namespace FA_1.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View(_context.Reports.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName");
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Add(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", report.CitizenID);
            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }

            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", report.CitizenID);
            return View(report);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Update(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", report.CitizenID);
            return View(report);
        }

        // GET: Reports/ReviewReport/5
        public ActionResult ReviewReport(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/ReviewReport/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewReport(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Reports.Update(report);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }
            _context.Reports.Remove(report);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}