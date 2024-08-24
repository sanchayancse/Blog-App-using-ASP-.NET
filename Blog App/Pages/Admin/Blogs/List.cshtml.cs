using Blog_App.Data;
using Blog_App.Models.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_App.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;
        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public void OnGet()
        {
            BlogPosts =  blogDbContext.BlogPosts.ToList();
        }
    }
}
