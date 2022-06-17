using PlaneEncyclopedia.Models;
namespace PlaneEncyclopedia.Services
{
    public interface IMissileService
    {
        public void Create(Missile missile,string userId);
        public void Update(Missile missile);
        public void Delete(Guid id);
        public Missile Get(Guid id);
        public List<Missile> GetAll();
    }
}
