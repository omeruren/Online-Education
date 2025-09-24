using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.ContactDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.ViewComponents.Contact
{
    public class _ContactInfo : ViewComponent
    {
        private readonly HttpClient _client;

        public _ContactInfo(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("RensEduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");

            return View(values);
        }
    }
}
