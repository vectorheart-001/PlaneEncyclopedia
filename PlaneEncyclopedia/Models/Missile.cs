using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace PlaneEncyclopedia.Models
{
    public class Missile
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public int Range { get; set; }
        
        public string ImagePath { get; set; }
        
        public string Type { get; set; }
        //many-to-many relationship
        public List<PlaneMissilesMapper> planeMissilesMappers { get; set; }
        //Relationship:One-to-many
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
