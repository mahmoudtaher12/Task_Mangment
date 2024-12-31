using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Yassinmohammed_w2_0523057.Models.Entites
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }

        public DateTime Deadline { get; set; }  
        public int projectId { get; set; }
        public int TeamMemberId { get; set; }

        public Projects? Projects { get; set; }
        public TeamMember? TeamMembers { get; set; }
    }
}
