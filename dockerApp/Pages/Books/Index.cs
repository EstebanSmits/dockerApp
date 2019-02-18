using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dockerApp.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dockerApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookDbContext _db;

        public IndexModel(BookDbContext db)
        {
            _db = db;
        }

        public IList<Book> Books { get; private set; }

        public async Task OnGetAsync()
        {
            Books = await _db.Book.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var book = await _db.Book.FindAsync(id);

            if (book != null)
            {
                _db.Book.Remove(book);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}