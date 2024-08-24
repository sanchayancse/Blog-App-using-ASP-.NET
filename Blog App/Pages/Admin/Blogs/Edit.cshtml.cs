using Blog_App.Data;
using Blog_App.Models.Domain;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_App.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost = await blogDbContext.BlogPosts.FindAsync(id);

        }

        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost =await blogDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if(existingBlogPost != null)
            {
                existingBlogPost.Headig = BlogPost.Headig;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }

           await blogDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlogPost =await blogDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null)
            {
                blogDbContext.BlogPosts.Remove(existingBlogPost);
                await blogDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Blogs/List");
            }
                return RedirectToPage("/Admin/Blogs/List");

        }
    }
}
