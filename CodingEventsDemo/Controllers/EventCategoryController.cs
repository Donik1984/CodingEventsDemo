using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext _context;
        public EventCategoryController(EventDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = _context.EventCategories.ToList();   
            return View(eventCategories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();

            return View (addEventCategoryViewModel);
        }
        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {

            if (ModelState.IsValid)
            {
                EventCategory newEventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name
                };

                _context.EventCategories.Add(newEventCategory); // This stages the data
                _context.SaveChanges(); // This actually saves the data in the DB

                return Redirect("/EventCategory");
            }

            return View(addEventCategoryViewModel);
        }
        public IActionResult Delete()
        {
            ViewBag.eventCategories = _context.EventCategories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventCategoriesIds)
        {
            foreach (int eventCategoryId in eventCategoriesIds)
            {
                EventCategory theEventCategory = _context.EventCategories.Find(eventCategoryId);
                _context.EventCategories.Remove(theEventCategory);
            }

            _context.SaveChanges();

            return Redirect("/EventCategory");
        }
    }
}
