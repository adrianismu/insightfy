using Insightify.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Insightify.ViewModels
{
    public class DashboardViewModel
    {
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
        public string SelectedCountry { get; set; } = string.Empty;
        public string SelectedCategory { get; set; } = string.Empty;
        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public string SourceChartJsonData { get; set; } = string.Empty;
    }
}
