namespace dotnet_mvc_svg.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int ContestantId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Message { get; set; } = "";
    }
}