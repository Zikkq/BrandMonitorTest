using System.ComponentModel;
using BrandMonitorTest.Data;
using BrandMonitorTest.Data.Dtos;
using BrandMonitorTest.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrandMonitorTest.Controllers
{
    [ApiController]
    [Route("api")]
    public sealed class Controller : ControllerBase
    {
        private readonly TaskRepo _taskRepo;
        private readonly string _dbConnectionString;

        public Controller(TaskRepo taskRepo, IConfiguration config)
        {
            _taskRepo = taskRepo;
            _dbConnectionString = config.GetConnectionString("DefaultConnection");
        }

        [HttpPost("task")]
        public async Task<ActionResult<Guid>> PostTask(CancellationToken ct)
        {
            var guid = await _taskRepo.UpsertTaskAsync(ct);
            var bw = new BackgroundWorker();
            bw.DoWork += async delegate
            {
                await Task.Delay(1000);
                await PerformUpdateAsync(SomeTaskStatus.Running);
                await Task.Delay((int)TimeSpan.FromMinutes(2).TotalMilliseconds);
                await PerformUpdateAsync(SomeTaskStatus.Finished);
            };
            bw.RunWorkerAsync();
            return Accepted(guid);

            async Task PerformUpdateAsync(string status)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseNpgsql(_dbConnectionString);
                using var context = new Context(optionsBuilder.Options);
                var task = await context.Tasks.FirstAsync(x => x.Guid == guid);
                task.Status = status;
                task.Timestamp = DateTime.Now.ToUniversalTime();
                await context.SaveChangesAsync();
            }
        }

        [HttpGet("task")]
        public async Task<ActionResult<SomeTaskDto>> GetTask([FromQuery] string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest();
            }
            var task = await _taskRepo.GetTaskAsync(guid);
            if (task is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new SomeTaskDto(task.Status, task.Timestamp));
            }
        }
    }
}