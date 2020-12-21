using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Data;
using AutoMapper;
using BookStore.DTO;
using System;
using System.Linq;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int bookId);
        Task<BookType> GetBooksFollowType(int typeId);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int bookId);
    }
    public class BookRepository : IBookRepository
    {
        private readonly BookStoredbContext bookStoredbContext;
    

        public BookRepository(BookStoredbContext bookStoredbContext, IMapper mapper)
        {
            this.bookStoredbContext = bookStoredbContext;
            
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
               
            var result =  await bookStoredbContext.Book.Where(Book => Book.IsDeleted == false).Include(b => b.BookBookType).ThenInclude(bbts => bbts.BookType).ToListAsync();
            return result;

        }

        public async Task<Book> GetBook(int bookId)
        {
            return await bookStoredbContext.Book.Include(b => b.BookBookType).ThenInclude(bbts => bbts.BookType)
                .FirstOrDefaultAsync(e => e.BookId == bookId);
        }

        public async Task<Book> AddBook(Book book)
        {
      
            //add to book table
            var result = await bookStoredbContext.Book.AddAsync(book);
            await bookStoredbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> UpdateBook(Book book)
        {

            var result = await bookStoredbContext.Book
                .FirstOrDefaultAsync(e => e.BookId == book.BookId);

            if (result != null)
            {
                ///  result = mapper.Map<Book>(book);
                result.BookName = book.BookName;
                result.BookImage = book.BookImage;
                result.BookPrice = book.BookPrice;
                result.IsDeleted = book.IsDeleted;
                await bookStoredbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Book> DeleteBook(int bookId)
        {
            //delete Book 

            var result = await bookStoredbContext.Book
                .FirstOrDefaultAsync(e => e.BookId == bookId);
            if (result != null)
            {
                bookStoredbContext.Book.Remove(result);
                await bookStoredbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<BookType> GetBooksFollowType(int typeId)
        {
            var result = await bookStoredbContext.BookType.Include(b => b.BookBookType).ThenInclude(b => b.Book).FirstOrDefaultAsync(bt => bt.BookTypeId == typeId);
            return result;
        }
    }
}