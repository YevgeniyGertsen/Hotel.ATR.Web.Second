namespace Hotel.ATR.Web.Second.Models
{
    public class Team
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public string FullName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}