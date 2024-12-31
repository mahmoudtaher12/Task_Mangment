using Microsoft.Build.Evaluation;
using Yassinmohammed_w2_0523057.Models.Entites;

namespace Yassinmohammed_w2_0523057.Models.ViewModel
{
    public class ViewModel
    {
        public int TaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }

        public DateTime Deadline { get; set; }

        public int MemberId { get; set; }
        public int ProjectId { get; set; }

        public ICollection<Projects>? Projects { get; set; }
        public IEnumerable<TeamMember>? TeamMembers { get; set; }

    }
}
