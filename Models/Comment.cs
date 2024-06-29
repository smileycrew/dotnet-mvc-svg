namespace DotnetMvcSvg.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Contestant? Contestant { get; set; }
        public int ContestantId { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Message { get; set; } = "";
    }
}