using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yassinmohammed_w2_0523057.Models;
using Yassinmohammed_w2_0523057.Models.Entites;
using Yassinmohammed_w2_0523057.Models.ViewModel;

namespace Yassinmohammed_w2_0523057.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

            public TaskController(AppDbContext context)
            {
                _context = context;
            }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);


            var projectList = await _context.Projects.ToListAsync();
            var teamMemberList = await _context.TeamMembers.ToListAsync();

            var viewModel = new ViewModel
            {

                Projects = projectList,
                TeamMembers = teamMemberList,
                ProjectId = task.projectId,
                MemberId = task.TeamMemberId,
                Deadline = task.Deadline,
                Description = task.Description,
                priority = task.priority,
                status = task.status,   
                Title =  task.Title,
                
                
            };

            return View(viewModel);
        }


        [HttpPost]
            public async Task< IActionResult> Edit(ViewModel task, int id)
            {
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            t.Title = task.Title;
            t.Description = task.Description;
            t.priority = task.priority;
            t.status = task.status;
            t.Deadline = task.Deadline;
            t.projectId = task.ProjectId;
            t.TeamMemberId = task.MemberId;

            _context.Tasks.Update(t);
              await  _context.SaveChangesAsync();
              return RedirectToAction("Index","Project");
            }
        }

    }


