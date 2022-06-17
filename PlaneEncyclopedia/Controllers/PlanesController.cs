using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaneEncyclopedia.Data;
using PlaneEncyclopedia.Services;
using PlaneEncyclopedia.Models;

namespace PlaneEncyclopedia.Controllers
{
    public class PlanesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly IPlaneService planeService;
        public PlanesController(ApplicationDbContext context, UserManager<User> userManager, IPlaneService planeService)
        {
            this.planeService = planeService;
            this.userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Plane> planes = this.planeService.GetAll();
            return View(planes);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Plane plane = this.planeService.Get(id);
            if (plane == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plane);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(Plane plane, string id)
        {
            id = userManager.GetUserId(User);
            this.planeService.Create(plane, id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var plane = planeService.Get(id);
            string userId = userManager.GetUserId(User);
            if (plane == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (plane.UserId != userId)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(plane);
        }
        [HttpPost]
        public IActionResult Edit(Plane plane)
        {
            plane = planeService.Get(plane.Id);
            this.planeService.Update(plane);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var plane = this.planeService.Get(id);
            return View(plane);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(Plane plane)
        {
            this.planeService.Delete(plane.Id);
            return RedirectToAction(nameof(Index));
        }


    }
}
