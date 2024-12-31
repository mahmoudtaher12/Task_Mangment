using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Threading.Tasks;
using Yassinmohammed_w2_0523057.Models;
using Yassinmohammed_w2_0523057.Models.Entites;

namespace Yassinmohammed_w2_0523057.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext appDbContext;
        public TeamMemberController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var r = await appDbContext.TeamMembers.FirstOrDefaultAsync(x => x.Id == id);    
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamMember member,Tasks task)
        {
            appDbContext.TeamMembers.Update(member);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index","Project");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var r = await appDbContext.TeamMembers.FirstOrDefaultAsync(x => x.Id == id);
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TeamMember member,Tasks tasks)
        {
            var e = await appDbContext.Tasks.FirstOrDefaultAsync(x => x.Id ==  member.Id);
            if (e != null)
            {
                appDbContext.Tasks.Remove(e);
                await appDbContext.SaveChangesAsync();
            }

            appDbContext.TeamMembers.Remove(member);
            await appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Project");
        }


        public async Task<IActionResult> Details(int id)
        {
            var t = await appDbContext.TeamMembers.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id==id);
            return View(t);
        }
    }
}
