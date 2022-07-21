namespace BrandMonitorTest.Data.Dtos
{
    public sealed class SomeTaskDto
    {
        public SomeTaskDto(string status, DateTime timstamp)
        {
            Status = status;
            Timstamp = timstamp.ToString("o");
        }

        public string Status { get; }
        public string Timstamp { get; }
    }
}