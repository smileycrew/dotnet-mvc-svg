namespace DotnetMvcSvg.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public Contestant? Contestant { get; set; }
        public int ContestantId { get; set; }
        public DateTime DateAdded { get; set; }
        public int DaysSincePosted
        {
            get
            {
                int daysSincePosted = (DateTime.Now - DateAdded).Days;

                return daysSincePosted;
            }
        }
        public string Message { get; set; } = "";
    }
}