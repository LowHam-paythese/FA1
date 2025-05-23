﻿using FA_1.Data;
using FA_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA_1.Controllers
{
    public class CitizenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitizenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var citizens = _context.Citizens.ToList();
            return View(citizens);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Citizens.Add(citizen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citizen);
        }

        public IActionResult Edit(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }

        [HttpPost]
        public IActionResult Edit(Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Citizens.Update(citizen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citizen);
        }

        public IActionResult Delete(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var citizen = _context.Citizens.Find(id);
            _context.Citizens.Remove(citizen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var citizen = _context.Citizens.Find(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen);
        }
    }
}
