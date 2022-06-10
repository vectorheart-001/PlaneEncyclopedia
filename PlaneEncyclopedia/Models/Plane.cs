using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PlaneEncyclopedia.Models
{
    public class Plane
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set;  }
        
        public string Description { get; set; }
        //Relationship: many-to-many
        public List<PlaneMissilesMapper> planeMissilesMappers { get; set; }
        //Relationship:one-to-many
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
