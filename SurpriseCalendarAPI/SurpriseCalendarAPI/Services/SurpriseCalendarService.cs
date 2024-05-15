using SurpriseCalendarAPI.Dtos;
using SurpriseCalendarAPI.Repositories.Interfaces;
using SurpriseCalendarAPI.Services.Interfaces;

namespace SurpriseCalendarAPI.Services
{
    public class SurpriseCalendarService : ISurpriseCalendarService
    {
        private readonly ISurpriseCalendarRepository _repository;

        public SurpriseCalendarService(ISurpriseCalendarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SquareDto>> GetOpenSquaresAsync()
        {
            var openSquares = await _repository.GetOpenSquaresAsync();
            return openSquares.Select(s => new SquareDto
            {
                Row = s.Row,
                Column = s.Column,
                IsOpen = s.IsOpen,
                PrizeAmount = s.PrizeAmount
            }).ToList();
        }

        public async Task<SquareDto> ScratchSquareAsync(ScratchSquareDto scratchSquareDto)
        {
            if (await _repository.HasUserScratchedSquareAsync(scratchSquareDto.UserId))
            {
                return null;
            }
            var square = await _repository.ScratchSquareAsync(scratchSquareDto.Row, scratchSquareDto.Column, scratchSquareDto.UserId);
            return new SquareDto
            {
                Row = square.Row,
                Column = square.Column, 
                IsOpen = square.IsOpen,
                PrizeAmount = square.PrizeAmount
            };
        }

        public async Task InitializeSurpriseCalendarAsync()
        {
            await _repository.InitializeSurpriseCalendarAsync();
        }

    }
}
