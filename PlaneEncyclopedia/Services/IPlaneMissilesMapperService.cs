using PlaneEncyclopedia.Models;
namespace PlaneEncyclopedia.Services
{
    public interface IPlaneMissilesMapperService
    {
        public void Create(Guid id1, Guid id2,PlaneMissilesMapper planeMissilesMapper);
        public void Delete(Guid id1,Guid id2);
        public PlaneMissilesMapper Get(Guid id1,Guid id2);
        public List<PlaneMissilesMapper> GetAll();
    }
}
