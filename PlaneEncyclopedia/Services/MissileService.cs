using PlaneEncyclopedia.Services;
using PlaneEncyclopedia;
using PlaneEncyclopedia.Data;
using PlaneEncyclopedia.Models;
using Microsoft.EntityFrameworkCore;
namespace PlaneEncyclopedia.Services
{
    public class MissileService : IMissileService
    {
        private readonly ApplicationDbContext _context;
        public MissileService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Missile missile,string Id)
        {
            missile.UserId = Id;
            _context.Missiles.Add(missile);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var missile = _context.Missiles.Find(id);
            _context.Missiles.Remove(missile);
            _context.SaveChanges();
        }

        public Missile Get(Guid id)
        {
           return _context.Missiles.Find(id);
        }

        public List<Missile> GetAll()
        {
            return _context.Missiles
                .Include(m => m.User)
                .Select(m => new Missile()
                {
                    Id = m.Id,
                    UserId = m.UserId,
                    Name = m.Name,
                    Description = m.Description,
                    Range = m.Range,
                    ImagePath = m.ImagePath,
                    Type = m.Type,
                    User = new User()
                    {
                        Id = m.UserId,
                    }

                }).ToList();
        }

        public void Update(Missile missile)
        {
            _context.Missiles.Update(missile);
            _context.SaveChanges();
        }
    }
}
