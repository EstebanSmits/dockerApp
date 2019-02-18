using System.ComponentModel.DataAnnotations;

namespace dockerApp.Data
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }
         [ StringLength(100)]
        public string Author { get; set; }

    }
}