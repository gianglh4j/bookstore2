using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;

namespace BookStore.Repository
{
    public interface IBookTypeRepository
    {
        Task<IEnumerable<BookType>> GetBookTypes();
        Task<BookType> GetBookType(int bookTypeId);
        Task<BookType> AddBookType(BookType bookType);
        Task<BookType> UpdateBookType(BookType bookType);
        Task<BookType> DeleteBookType(int bookTypeId);
    }

    public class BookTypeRepository : IBookTypeRepository
    {
        private readonly BookStoredbContext bookStoredbContext;

        public BookTypeRepository(BookStoredbContext bookStoredbContext)
        {
            this.bookStoredbContext = bookStoredbContext;
        }

        public async Task<IEnumerable<BookType>> GetBookTypes()
        {
            return await bookStoredbContext.BookType.ToListAsync();
        }

        public async Task<BookType> GetBookType(int bookTypeId)
        {
            return await bookStoredbContext.BookType.Include(b=>b.BookBookType).ThenInclude(bbt=> bbt.Book)
                .FirstOrDefaultAsync(e => e.BookTypeId == bookTypeId);
        }

        public async Task<BookType> AddBookType(BookType bookType)
        {
            var result = await bookStoredbContext.BookType.AddAsync(bookType);
            await bookStoredbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BookType> UpdateBookType(BookType bookType)
        {
            var result = await bookStoredbContext.BookType
                .FirstOrDefaultAsync(e => e.BookTypeId == bookType.BookTypeId);

            if (result != null)
            {
                result.BookTypeName = bookType.BookTypeName;
               
                await bookStoredbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<BookType> DeleteBookType(int bookTypeId)
        {
            var result = await bookStoredbContext.BookType
                .FirstOrDefaultAsync(e => e.BookTypeId == bookTypeId);
            if (result != null)
            {
                bookStoredbContext.BookType.Remove(result);
                await bookStoredbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

    }
}