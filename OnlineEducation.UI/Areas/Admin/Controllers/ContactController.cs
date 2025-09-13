using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEducation.UI.DTOs.ContactDtos;
using OnlineEducation.UI.Helpers;

namespace OnlineEducation.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

   
        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }

        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {

            await _client.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateContactDto>($"contacts/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var values = await _client.PutAsJsonAsync("contacts", updateContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync($"contacts/{id}");
            return RedirectToAction(nameof(Index));
        }


    }
}
