using Insightify.Models.DTOs;

namespace Insightify.Services
{
    public interface INewsApiService
    {
        Task<NewsApiResponse> GetTopHeadlinesAsync(string country, string category);
    }
}
