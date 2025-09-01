using Insightify.Models.DTOs;
using System.Text.Json;

namespace Insightify.Services
{
    public class NewsApiService : INewsApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private const string BaseUrl = "https://newsapi.org/v2";

        public NewsApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<NewsApiResponse> GetTopHeadlinesAsync(string country, string category)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var apiKey = _configuration["NewsApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("NewsAPI key is not configured.");
            }

            // Bangun URL request
            var url = $"{BaseUrl}/top-headlines?country={country}&category={category}&apiKey={apiKey}";

            // Atur header User-Agent (praktik terbaik)
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Insightify/1.0");

            try
            {
                // Lakukan request GET
                var response = await httpClient.GetAsync(url);

                // Tangani jika respons tidak berhasil
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching news: {response.StatusCode} - {response.ReasonPhrase}");
                }

                // Baca konten respons sebagai string
                var jsonContent = await response.Content.ReadAsStringAsync();

                // Deserialisasi menjadi objek NewsApiResponse
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var newsApiResponse = JsonSerializer.Deserialize<NewsApiResponse>(jsonContent, options);

                return newsApiResponse ?? new NewsApiResponse { Articles = new List<ArticleDto>() };
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error processing news data: {ex.Message}", ex);
            }
        }
    }
}
