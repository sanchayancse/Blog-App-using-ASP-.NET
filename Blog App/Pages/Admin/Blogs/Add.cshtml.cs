using Blog_App.Data;
using Blog_App.Models.Domain;
using Blog_App.Models.ViewModels;
using Blog_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_App.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly BlogDbContext blogDbContext;
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var blogPost = new BlogPost()
            {
                Headig = AddBlogPostRequest.Headig,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };

            await blogPostRepository.AddAsync(blogPost);

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
