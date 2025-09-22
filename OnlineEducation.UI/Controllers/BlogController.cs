﻿using Microsoft.AspNetCore.Mvc;
using OnlineEducation.UI.DTOs.BlogDtos;
using OnlineEducation.UI.DTOs.SubscriberDtos;
using OnlineEducation.UI.Helpers;
using System.Threading.Tasks;

namespace OnlineEducation.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            await _client.PostAsJsonAsync("subscribers", createSubscriberDto);

            return NoContent();
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _client.GetFromJsonAsync<ResultBlogDto>($"blogs/{id}");
            return View(blog);
        }

        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>($"blogs/GetBlogsByCategoryId/{id}");

            ViewBag.categoryName = blogs.Select(x => x.BlogCategory.Name).FirstOrDefault();
            return View(blogs);
        }
    }
}
