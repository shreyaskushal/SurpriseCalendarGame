using SurpriseCalendarAPI.Models;

namespace SurpriseCalendarAPI.Repositories.Interfaces
{
    public interface ISurpriseCalendarRepository
    {
        Task<List<SurpriseCalendarSquare>> GetOpenSquaresAsync();
        Task<SurpriseCalendarSquare> ScratchSquareAsync(int row, int column, int userId);

        Task<bool> HasUserScratchedSquareAsync(int userId);
        Task InitializeSurpriseCalendarAsync();
    }
}
