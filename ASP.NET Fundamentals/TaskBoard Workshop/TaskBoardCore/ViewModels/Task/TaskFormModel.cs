namespace TaskBoard.Core.ViewModels.Task
{
    using System.ComponentModel.DataAnnotations;
    using TaskBoard.Core.ViewModels.Board;
    using static TaskBoardCommon.EntityValidation.TaskEntity;
    public class TaskFormModel
    {
        public TaskFormModel()
        {
            Boards = new List<TaskBoardFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title should be at least {2} characters long")]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength (DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Description should be at least {2} characters long")]
        public string Description { get; set; } = null!;
        public int? BoardId { get; set; }

        public IEnumerable<TaskBoardFormModel> Boards { get; set; } = null!;
    }
}
