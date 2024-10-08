using Blog_App.Data;
using Blog_App.Models.Domain;
using Blog_App.Models.ViewModels;
using Blog_App.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Blog_App.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet()
        {
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null) {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson.ToString());
            }
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
