using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Domain.Repositories.Abstract;

namespace OnlineBooks.Data
{
    public class DataManager
    {
        public IBooksRepository AllBooks { get; set; }

        public DataManager(IBooksRepository booksRepository)
        {
            AllBooks = booksRepository;
        }
    }
}
