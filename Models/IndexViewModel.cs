using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBooks.Models;

namespace OnlineBooks.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Books> MyBooks { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
