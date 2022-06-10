namespace PlaneEncyclopedia.Models
{
    public class PlaneMissilesMapper
    {
        public Guid PlaneId { get; set; }
        public Plane Plane { get; set; }
        public Guid  MissileId{get; set;}
        public Missile Missile { get; set; }
    }
}
