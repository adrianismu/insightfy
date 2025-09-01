using Insightify.Services;
using Insightify.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Insightify.Controllers
{
    public class DashboardController : Controller
    {
        private readonly INewsApiService _newsApiService;

        public DashboardController(INewsApiService newsApiService)
        {
            _newsApiService = newsApiService;
        }

        public async Task<IActionResult> Index(string country = "id", string category = "technology")
        {
            try
            {
                // Memanggil service untuk mendapatkan berita
                var newsResponse = await _newsApiService.GetTopHeadlinesAsync(country, category);

                // Mengolah data respons: mengelompokkan artikel berdasarkan nama sumber
                var sourceGroups = newsResponse.Articles?
                    .Where(a => a.Source?.Name != null)
                    .GroupBy(a => a.Source!.Name)
                    .Select(g => new { Source = g.Key, Count = g.Count() })
                    .ToList() ?? new List<dynamic>();

                // Mengonversi hasil olahan data grafik menjadi string JSON
                var chartData = sourceGroups.Select(sg => new { label = sg.Source, value = sg.Count }).ToList();
                var chartJsonData = JsonSerializer.Serialize(chartData);

                // Membuat instance DashboardViewModel
                var viewModel = new DashboardViewModel
                {
                    Articles = newsResponse.Articles ?? new List<Models.DTOs.ArticleDto>(),
                    SelectedCountry = country,
                    SelectedCategory = category,
                    SourceChartJsonData = chartJsonData,
                    Countries = GetCountries(),
                    Categories = GetCategories()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Handle error gracefully
                ViewBag.ErrorMessage = $"Error loading news: {ex.Message}";
                
                var errorViewModel = new DashboardViewModel
                {
                    SelectedCountry = country,
                    SelectedCategory = category,
                    Countries = GetCountries(),
                    Categories = GetCategories()
                };

                return View(errorViewModel);
            }
        }

        private List<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "id", Text = "Indonesia" },
                new SelectListItem { Value = "us", Text = "United States" },
                new SelectListItem { Value = "gb", Text = "United Kingdom" },
                new SelectListItem { Value = "au", Text = "Australia" },
                new SelectListItem { Value = "ca", Text = "Canada" },
                new SelectListItem { Value = "de", Text = "Germany" },
                new SelectListItem { Value = "fr", Text = "France" },
                new SelectListItem { Value = "jp", Text = "Japan" },
                new SelectListItem { Value = "kr", Text = "South Korea" },
                new SelectListItem { Value = "sg", Text = "Singapore" }
            };
        }

        private List<SelectListItem> GetCategories()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "business", Text = "Business" },
                new SelectListItem { Value = "entertainment", Text = "Entertainment" },
                new SelectListItem { Value = "general", Text = "General" },
                new SelectListItem { Value = "health", Text = "Health" },
                new SelectListItem { Value = "science", Text = "Science" },
                new SelectListItem { Value = "sports", Text = "Sports" },
                new SelectListItem { Value = "technology", Text = "Technology" }
            };
        }
    }
}
