using FA_1.Data;
using FA_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA_1.Controllers
{
    public class ServiceRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceRequest
        public IActionResult Index()
        {
            var serviceRequests = _context.ServiceRequests.ToList();
            return View(serviceRequests);
        }

        // GET: ServiceRequest/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = _context.ServiceRequests.FirstOrDefault(m => m.RequestID == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // GET: ServiceRequest/Create
        public IActionResult Create()
        {
            ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName");
            return View();

        }

        // POST: ServiceRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model state is invalid. Listing errors:");

                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Field: {key}, Error: {error.ErrorMessage}");
                    }
                }

                ViewData["CitizenID"] = new SelectList(_context.Citizens, "CitizenID", "FullName", serviceRequest.CitizenID);
                return View(serviceRequest);
            }
            else
            {
                Console.WriteLine("Modelstate is true");
            }

                _context.ServiceRequests.Add(serviceRequest);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // GET: ServiceRequest/UpdateStatus/5
        public IActionResult UpdateStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = _context.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return View(serviceRequest);
        }

        // POST: ServiceRequest/UpdateStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Update(serviceRequest);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequest/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = _context.ServiceRequests.FirstOrDefault(m => m.RequestID == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // POST: ServiceRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var serviceRequest = _context.ServiceRequests.Find(id);
            _context.ServiceRequests.Remove(serviceRequest);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}