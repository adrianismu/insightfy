namespace Insightify.Models.DTOs
{
    public class NewsApiResponse
    {
        public string? Status { get; set; }
        public int TotalResults { get; set; }
        public List<ArticleDto>? Articles { get; set; }
    }
}
