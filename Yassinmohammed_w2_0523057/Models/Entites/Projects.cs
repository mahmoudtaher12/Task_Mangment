using System.ComponentModel.DataAnnotations;

namespace Yassinmohammed_w2_0523057.Models.Entites
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Tasks>? Tasks { get; set; }
    }
}
