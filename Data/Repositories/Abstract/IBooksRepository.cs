using System;
using System.Linq;
using OnlineBooks.Models;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IBooksRepository
    {
        IQueryable<Books> GetBookItems();
        Books GetBookItemById(Guid id);
        void SaveBooks(Books entity);
        void DeleteBook(Guid id);
    }
}