using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {

        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Dish> dishes = _context.Dishes
                .ToList();
            
            return View(dishes);
        }

        public IActionResult AddDish()
        {
            return View();
        }

        [HttpGet("{DishID}")]
        public IActionResult ViewDish(int dishID)
        {
            Dish dish = _context.Dishes.FirstOrDefault(d => (int)d.DishID == dishID);
            return View("ViewDish", dish);
        }

        [HttpGet("delete/{DishID}")]
        public IActionResult DeleteDish(int dishID)
        {
            Dish DBdish = _context.Dishes.FirstOrDefault(d => (int)d.DishID == dishID);
            _context.Dishes.Remove(DBdish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{DishID}")]
        public IActionResult EditDish(int dishID)
        {
            Dish dish = _context.Dishes.FirstOrDefault(d => (int)d.DishID == dishID);
            return View("EditDish", dish);
        }

        [HttpPost("submit-new")]
        public IActionResult SubmitNewDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dish);
                _context.SaveChanges();
                return Redirect($"/{dish.DishID}");
            }
            else
            {
                return View("AddDish");
            }
        }

        [HttpPost("submit")]

        public IActionResult SubmitDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                Dish MyDish = _context.Dishes
                    .FirstOrDefault(d => d.DishID == dish.DishID);
                MyDish.Name = dish.Name;
                MyDish.Chef = dish.Chef;
                MyDish.Calories = dish.Calories;
                MyDish.Tastiness = dish.Tastiness;
                MyDish.Description = dish.Description;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish", dish);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
