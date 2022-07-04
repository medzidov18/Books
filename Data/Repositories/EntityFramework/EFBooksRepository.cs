using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Repositories.Abstract;
using OnlineBooks.Models;

namespace OnlineBooks.Data.Repositories.EntityFramework
{
    public class EFBooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext context;

        public EFBooksRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Books> GetBookItems()
        {
            return context.AllBooks;
        }

        public Books GetBookItemById(Guid id)
        {
            return context.AllBooks.FirstOrDefault(x => x.Id == id);
        }

        public void SaveBooks(Books entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            context.AllBooks.Remove(new Books() { Id = id });
            context.SaveChanges();
        }
    }
}
