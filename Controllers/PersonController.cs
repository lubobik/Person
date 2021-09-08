
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Test;
using Test.Models;

namespace personManagement.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext db;

        public PersonController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var persons = db.Persons.ToList();
            ViewBag.Persons = persons;
            return View();
        }

        public IActionResult Grid()
        {
            return View(db.Persons.ToList());
        }

        public IActionResult SearchGrid(string search)
        {
            int id=0;
            try
            {
                id = Int32.Parse(search);
            }
            catch (Exception)
            {
            }
            var persons = from p in db.Persons
                          select p;
            persons = persons.Where(p => p.Id.Equals(id) || p.Firstname.Contains(search) || p.Lastname.Contains(search));
            return View("Grid", persons.ToList());
        }

        [HttpGet]
        public IActionResult Filter(int Id, String Firstname, String Lastname, bool isCompany)
        {
            var persons = from p in db.Persons
                          select p;
            persons = persons.Where(p => p.isCompany.Equals(isCompany));
            if (Lastname != null)
            {
                persons = persons.Where(p => p.Lastname.Contains(Lastname));
            }
            if (Id != 0)
            {
                persons = persons.Where(p => p.Id.Equals(Id));
            }
            if (Firstname != null)
            {
                persons = persons.Where(p => p.Firstname.Contains(Firstname) || p.Firstname.Equals(""));

            }

            ViewBag.Persons = persons;
            return View("Index");
        }


        public IActionResult Edit(int id)
        {
            var person = db.Persons.Find(id);
            if (id == 0)
            {
                ViewData["Title"] = "Create a Person";
                return View("CreateEdit");
            }
            if (person == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Edit a Person";
            return View("CreateEdit", person);
        }
        [HttpPost]
        public IActionResult CreateEdit(Person person)
        {
            if (person.isCompany)
            {
                person.Firstname="";
            }
            if (person.Id == 0)
            {
                db.Persons.Add(person);
            }
            else
            {
                db.Persons.Update(person);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var personInDb = db.Persons.Find(id);
            if (personInDb == null)
            {
                return NotFound();
            }
            db.Persons.Remove(personInDb);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
