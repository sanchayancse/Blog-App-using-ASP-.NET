using Blog_App.Data;
using Blog_App.Models.Domain;
using Blog_App.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog_App.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);

        }

        public async Task<IActionResult> OnPostEdit()
        {
            await blogPostRepository.UpdateAsync(BlogPost);
            ViewData["MessageDescription"] = "Record was successfully saved!";

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                return RedirectToPage("/Admin/Blogs/List");

            }

            return Page();

        }
    }
}
