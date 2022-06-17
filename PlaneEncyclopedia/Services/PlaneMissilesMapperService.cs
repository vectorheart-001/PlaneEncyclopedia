using PlaneEncyclopedia.Services;
using PlaneEncyclopedia.Models;
using PlaneEncyclopedia.Data;
using Microsoft.EntityFrameworkCore;

namespace PlaneEncyclopedia.Services
{
    public class PlaneMissilesMapperService : IPlaneMissilesMapperService
    {
        private readonly ApplicationDbContext _context;
        public PlaneMissilesMapperService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Guid id1,Guid id2,PlaneMissilesMapper planeMissilesMapper)
        {
            planeMissilesMapper.PlaneId = id1;
            planeMissilesMapper.MissileId = id2;
            _context.Add(planeMissilesMapper);
            _context.SaveChanges();
        }

        public void Delete(Guid id1,Guid id2)
        {
            var planeMissilesMapper = _context.PlaneMissilesMapper.Find(id1,id2);
            _context.PlaneMissilesMapper.Remove(planeMissilesMapper);
            _context.SaveChanges();
        }

        public PlaneMissilesMapper Get(Guid id1,Guid id2)
        {
            return _context.PlaneMissilesMapper.Find(id1,id2);
        }

        public List<PlaneMissilesMapper> GetAll()
        {
            return _context.PlaneMissilesMapper
               .Include(pm => pm.Missile)
               .Include(pm => pm.Plane)
               .Select(pm => new PlaneMissilesMapper()
               {
                   Missile = new Missile()
                   {
                       Id = pm.Missile.Id,
                       Name = pm.Missile.Name,
                       Description =pm.Missile.Description,
                       Range = pm.Missile.Range,
                       ImagePath = pm.Missile.ImagePath,
                       Type = pm.Missile.Type,
                       User = new User()
                       {
                          Id = pm.Missile.UserId,
                       }
                   },
                   Plane = new Plane()
                   {
                       Id = pm.Plane.Id,
                       Name = pm.Plane.Name,
                       Description = pm.Plane.Description,
                       ImagePath = pm.Plane.ImagePath,
                       User = new User()
                       {
                           Id = pm.Plane.UserId,
                       }
                   }

               }).ToList();
        }

        
    }
}
