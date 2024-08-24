using Blog_App.Data;
using Blog_App.Models.Domain;
using Blog_App.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var messageDescription = (string)TempData["MessageDescription"];
            if (!string.IsNullOrWhiteSpace(messageDescription)) { 
                ViewData["MessageDescription"] = messageDescription;
            }
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
