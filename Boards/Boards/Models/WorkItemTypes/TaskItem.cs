namespace Boards.Models.WorkItemTypes
{
    public class TaskItem : WorkItem
    {
        public string Activity { get; set; }
        public decimal RemainingWork { get; set; }
    }
}
