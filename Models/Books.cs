using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class Books
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookFilePath { get; set; }
    }
}
