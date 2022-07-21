using BrandMonitorTest.Data.Entities;
using BrandMonitorTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BrandMonitorTest.Data
{
    public sealed class TaskRepo
    {
        private readonly Context _context;
        public TaskRepo(Context context)
        {
            _context = context;
        }

        public async Task<Guid> UpsertTaskAsync(CancellationToken ct)
        {
            var id = Guid.NewGuid();
            await _context.Tasks.AddAsync(new SomeTask
            {
                Guid = id,
                Timestamp = DateTime.Now.ToUniversalTime(),
                Status = SomeTaskStatus.Created
            }, ct);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<SomeTask?> GetTaskAsync(Guid guid) =>
            await _context.Tasks.FirstOrDefaultAsync(x => x.Guid == guid);

        public string? GetConnectionString() =>
            _context.Database.GetConnectionString();
    }
}