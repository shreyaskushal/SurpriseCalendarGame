using Microsoft.EntityFrameworkCore;
using SurpriseCalendarAPI.Data;
using SurpriseCalendarAPI.Models;
using SurpriseCalendarAPI.Repositories.Interfaces;

namespace SurpriseCalendarAPI.Repositories
{
    public class SurpriseCalendarRepository : ISurpriseCalendarRepository
    {
        private readonly SurpriseCalendarContext _context;

        public SurpriseCalendarRepository(SurpriseCalendarContext context)
        {
            _context = context;
        }

        public async Task<List<SurpriseCalendarSquare>> GetOpenSquaresAsync()
        {
            return await _context.SurpriseCalendar.Where(s => s.IsOpen).ToListAsync();
        }

        public async Task<SurpriseCalendarSquare> ScratchSquareAsync(int row, int column, int userId)
        {
            var square = await _context.SurpriseCalendar.FirstOrDefaultAsync(s => s.Row == row && s.Column == column);
            if (square != null && !square.IsOpen)
            {
                square.IsOpen = true;
                square.UserId = userId;
                _context.SurpriseCalendar.Update(square);
                await _context.SaveChangesAsync();
            }
            return square;
        }

        public async Task<bool> HasUserScratchedSquareAsync(int userId)
        {
            return await _context.SurpriseCalendar.AnyAsync(s => s.UserId == userId);
        }

        public async Task InitializeSurpriseCalendarAsync()
        {
            if (!await _context.SurpriseCalendar.AnyAsync())
            {
                var squares = new List<SurpriseCalendarSquare>();
                var random = new Random();

                for (int row = 1; row <= 100; row++)
                {
                    for (int column = 1; column <= 100; column++)
                    {
                        squares.Add(new SurpriseCalendarSquare
                        {
                            Row = row,
                            Column = column,
                            IsOpen = false,
                            PrizeAmount = 0
                        });
                    }
                }

                // Assign main prize
                var mainPrizeIndex = random.Next(0, squares.Count);
                squares[mainPrizeIndex].PrizeAmount = 25000;

                // Assign 100 consolation prizes
                for (int i = 0; i < 100; i++)
                {
                    int consolationPrizeIndex;
                    do
                    {
                        consolationPrizeIndex = random.Next(0, squares.Count);
                    } while (squares[consolationPrizeIndex].PrizeAmount != 0);

                    squares[consolationPrizeIndex].PrizeAmount = 100;
                }

                await _context.SurpriseCalendar.AddRangeAsync(squares);
                await _context.SaveChangesAsync();
            }
        }

    }
}
