namespace TaskBoardCore.ViewModels.Board
{
    using TaskBoardCore.ViewModels.Task;

    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }
        public int Id { get; init; }

        public string Name { get; set; } = null!;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = null!;
    }
}
