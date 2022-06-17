using PlaneEncyclopedia.Models;
namespace PlaneEncyclopedia.Services
{
    public interface IPlaneService
    {
        public void Create(Plane plane, string userId);
        public void Update(Plane plane);
        public void Delete(Guid id);
        public Plane Get(Guid id);
        public List<Plane> GetAll();
    }
}
