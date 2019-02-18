using System.Threading.Tasks;
using dockerApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dockerApp.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookDbContext _db;

        public CreateModel(BookDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Book.Add(Book);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Books/Index");
        }
    }
}