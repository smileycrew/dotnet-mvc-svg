namespace DotnetMvcSvg.Models.DTOs
{
    public class HomeDTO
    {
        public List<CommentDTO>? Comments { get; set; }
        public List<ContestantDTO>? Contestants { get; set; }
        public string? UserComment { get; set; }
    }
}