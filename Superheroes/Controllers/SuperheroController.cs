using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext context;
        public SuperheroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superhero
        public ActionResult Index()
        {
            var heroes = context.SuperHeroes.ToList();
            return View(heroes);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superhero = new SuperHero();
            superhero = context.SuperHeroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            SuperHero superhero = new SuperHero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo")]SuperHero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.SuperHeroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superhero = new SuperHero();
            superhero = context.SuperHeroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit(SuperHero superhero)
        {
            try
            {
                // TODO: Add update logic here
                var updateHero = context.SuperHeroes.Where(s => s.Id == superhero.Id).Select(s => s).SingleOrDefault();
                updateHero.Name = superhero.Name;
                updateHero.AlterEgo = superhero.AlterEgo;
                updateHero.PrimaryAbility = superhero.PrimaryAbility;
                updateHero.SecondaryAbility = superhero.SecondaryAbility;
                updateHero.CatchPhrase = superhero.CatchPhrase;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero superhero = new SuperHero();
            superhero = context.SuperHeroes.Where(s => s.Id == id).Select(s => s).SingleOrDefault();            
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        public ActionResult Delete(SuperHero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                //
                context.SuperHeroes.Remove(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
