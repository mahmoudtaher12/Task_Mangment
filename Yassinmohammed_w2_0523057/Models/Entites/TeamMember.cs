using System.ComponentModel.DataAnnotations;

namespace Yassinmohammed_w2_0523057.Models.Entites
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

        public string role { get; set; }
        public ICollection<Tasks>? Tasks { get; set; }
    }
}
