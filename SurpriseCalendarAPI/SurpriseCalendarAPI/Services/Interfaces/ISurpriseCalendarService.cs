using SurpriseCalendarAPI.Dtos;

namespace SurpriseCalendarAPI.Services.Interfaces
{
    public interface ISurpriseCalendarService
    {
        Task<List<SquareDto>> GetOpenSquaresAsync();
        Task<SquareDto> ScratchSquareAsync(ScratchSquareDto scratchSquareDto);
        Task InitializeSurpriseCalendarAsync();
    }
}
