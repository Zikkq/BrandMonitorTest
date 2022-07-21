using System.ComponentModel.DataAnnotations;

namespace BrandMonitorTest.Data.Entities
{
    public sealed class SomeTask
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public DateTime Timestamp { get; set; }

#nullable disable
        [Required] public string Status { get; set; }
#nullable enable
    }
}