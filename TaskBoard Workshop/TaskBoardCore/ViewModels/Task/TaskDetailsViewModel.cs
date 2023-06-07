namespace TaskBoard.Core.ViewModels.Task
{
    using TaskBoardCore.ViewModels.Task;
    public class TaskDetailsViewModel : TaskViewModel
    {
        public string CreatedOn { get; init; } = null!;
        public string Board { get; init; } = null!; 
    }
}
