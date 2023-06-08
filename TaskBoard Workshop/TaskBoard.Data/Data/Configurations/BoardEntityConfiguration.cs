using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Data.Models;

namespace TaskBoard.Data.Data.Configurations
{
    internal class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            ICollection<Board> boards = CreateBoards();
            builder.HasData(boards);
        }
        private ICollection<Board> CreateBoards()
        {

         ICollection<Board> boards = new List<Board>()
        {
            new Board()
            {
                Id = 1,
                Name = "Open",
            },

            new Board()
            {
                Id = 2,
                Name = "In Progress"
            },

            new Board()
            {
                Id = 3,
                Name = "Done"
            }
        };
            return boards;
        }
    }
}
