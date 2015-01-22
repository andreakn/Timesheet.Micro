namespace Timesheet.Micro.Models.Domain.Model
{
    public class TimeEntry : ProjectTime
    {
        public virtual double? HourlyRate { get; set; }
        public virtual string Comment { get; set; }
    }
}
