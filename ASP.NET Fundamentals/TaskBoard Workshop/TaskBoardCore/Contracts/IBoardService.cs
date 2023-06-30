using TaskBoard.Core.ViewModels.Board;
using TaskBoardCore.ViewModels.Board;

namespace TaskBoardCore.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetAllBoards();

        Task<IEnumerable<TaskBoardFormModel>> GetExistingBoards();
    }
}
