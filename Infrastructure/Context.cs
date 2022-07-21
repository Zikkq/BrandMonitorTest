using BrandMonitorTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrandMonitorTest.Infrastructure
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<SomeTask> Tasks { get; init; }
#nullable enable
    }
}