using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class Books
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название книги")]
        public string BookName { get; set; }
        
        [Display(Name = "Автор книги")]
        public string BookAuthor { get; set; }
        
        [Display(Name = "Файл книги")]
        public string BookFilePath { get; set; }
    }
}
