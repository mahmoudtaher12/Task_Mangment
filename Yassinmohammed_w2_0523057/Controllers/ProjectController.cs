using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Yassinmohammed_w2_0523057.Models;
using Yassinmohammed_w2_0523057.Models.Entites;

namespace Yassinmohammed_w2_0523057.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProjectController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task< IActionResult> Index()
        {
            var r = await _appDbContext.Projects.ToListAsync();
            return View(r);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Projects projects)
        {
            await _appDbContext.Projects.AddAsync(projects);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var r = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

            return View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Projects projects)
        {
             _appDbContext.Projects.Update(projects);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var r = await _appDbContext.Projects.Include(t => t.Tasks)
                .ThenInclude(c => c.TeamMembers)
                .FirstOrDefaultAsync(x => x.Id == id);
           

            return View(r);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var r = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

            return View(r);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Projects projects)
        {
            // var r = await _appDbContect.Tasks.FirstOrDefaultAsync(x => x.Id = projects.Id);
            //if (r != null)
            //{
            //appDbContext.Tasks.Remove(r);
            //appDbContext.SavechangesAsync();
            //}

            _appDbContext.Projects.Remove(projects);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
