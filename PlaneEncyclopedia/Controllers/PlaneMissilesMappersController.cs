using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaneEncyclopedia.Data;
using PlaneEncyclopedia.Services;
using PlaneEncyclopedia.Models;

namespace PlaneEncyclopedia.Controllers
{
    public class PlaneMissilesMappersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPlaneMissilesMapperService _planeMissilesMapperService;

        public PlaneMissilesMappersController(ApplicationDbContext context,IPlaneMissilesMapperService planeMissilesMapperService)
        {
            this._planeMissilesMapperService = planeMissilesMapperService;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlaneMissilesMapper.Include(p => p.Missile).Include(p => p.Plane);
            return View(await applicationDbContext.ToListAsync());
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    List<PlaneMissilesMapper> armaments = _planeMissilesMapperService.GetAll();
        //    return View(armaments);
        //}

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PlaneId"] = new SelectList(_context.Planes, "Id", "Name");
            ViewData["MissileId"] = new SelectList(_context.Missiles, "Id", "Name");
            return View();
        }


        [HttpPost]

        public IActionResult Create(Guid id1,Guid id2,PlaneMissilesMapper planeMissilesMapper)
        {
            ViewData["PlaneId"] = new SelectList(_context.Planes, "Id", "Name", planeMissilesMapper.PlaneId);
            ViewData["MissileId"] = new SelectList(_context.Missiles, "Id", "Name", planeMissilesMapper.MissileId);
            this._planeMissilesMapperService.Create(planeMissilesMapper.PlaneId,planeMissilesMapper.MissileId,planeMissilesMapper);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(Guid missileId, Guid planeId)
        {
            var pm = this._planeMissilesMapperService.Get(missileId,planeId);
            return View(pm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(PlaneMissilesMapper planeMissilesMapper)
        {
            this._planeMissilesMapperService.Delete(planeMissilesMapper.MissileId,planeMissilesMapper.PlaneId);

            return RedirectToAction(nameof(Index));
        }


    }
}
