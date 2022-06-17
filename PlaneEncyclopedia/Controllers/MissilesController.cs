using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaneEncyclopedia.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaneEncyclopedia.Data;
using Microsoft.AspNetCore.Identity;
using PlaneEncyclopedia.Models;
using PlaneEncyclopedia.Services;

namespace PlaneEncyclopedia.Controllers
{
    public class MissilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly IMissileService missileService;
        public MissilesController(ApplicationDbContext context, UserManager<User> userManager, IMissileService missileService)
        {
            this.missileService = missileService;
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Missile> missiles = this.missileService.GetAll();
            return View(missiles);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Missile missile = this.missileService.Get(id);
            if (missile == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(missile);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(Missile missile, string id)
        {
            id = userManager.GetUserId(User);
            this.missileService.Create(missile, id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var missile = missileService.Get(id);
            string userId = userManager.GetUserId(User);
            if (missile == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (missile.UserId != userId)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Missile missile)
        {
            missile = missileService.Get(missile.Id);
            this.missileService.Update(missile);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var missile = this.missileService.Get(id);
            return View(missile);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(Missile missile)
        {
            this.missileService.Delete(missile.Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
