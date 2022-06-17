using PlaneEncyclopedia.Models;
using PlaneEncyclopedia.Data;
using Microsoft.EntityFrameworkCore;
namespace PlaneEncyclopedia.Services
{
    public class PlaneService:IPlaneService
    {
        private readonly ApplicationDbContext _context;
        public PlaneService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Plane plane, string Id)
        {
            plane.UserId = Id;
            _context.Planes.Add(plane);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var plane = _context.Planes.Find(id);
            _context.Planes.Remove(plane);
            _context.SaveChanges();
        }

        public Plane Get(Guid id)
        {
            return _context.Planes.Find(id);
        }

        public List<Plane> GetAll()
        {
            return _context.Planes
                .Include(p => p.User)
                .Select(p => new Plane()
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Name = p.Name,
                    ImagePath = p.ImagePath,
                    Description = p.Description,
                    User = new User()
                    {
                        Id = p.UserId,
                    }

                }).ToList();
        }

        public void Update(Plane plane)
        {
            _context.Planes.Update(plane);
            _context.SaveChanges();
        }
    }
}
