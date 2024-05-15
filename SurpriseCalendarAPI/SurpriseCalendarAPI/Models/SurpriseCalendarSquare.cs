namespace SurpriseCalendarAPI.Models
{
    public class SurpriseCalendarSquare
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsOpen { get; set; }
        public int PrizeAmount { get; set; }
        public int? UserId { get; set; }
    }
}
