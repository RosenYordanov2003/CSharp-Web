namespace TaskBoard.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static TaskBoardCommon.EntityValidation.BoardEntity;
    public class Board
    {
        public Board()
        {
            Tasks = new List<Task>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public IEnumerable<Task> Tasks { get; set; } = null!;
    }
}
