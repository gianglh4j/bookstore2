using AutoMapper;
using BookStore.DTO;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DomainLogic;

namespace BookStore.ApplicationLogic
{
    public interface IBookApplicationLogics
    {
        Book setBookPost(BookDTO bookDTO);

        Task<Book> addBook(BookDTO bookDTO);

        Task<Book> updateBook(BookDTO bookDTO);

        Task<IEnumerable<BookDTO>> getBooksFollowType(int typeId);

        Task<IEnumerable<BookDTO>> getBooks();

        Task<BookDTO> getBook(int bookId);

    }

    public class BookApplicationLogics : IBookApplicationLogics
    {
        private readonly IMapper mapper;
        private readonly IBookLogic _bookLogic;
        public BookApplicationLogics(IMapper mapper, IBookLogic bookLogic)
        {
            this.mapper = mapper;
            this._bookLogic = bookLogic;
        }

        public async Task<Book> addBook(BookDTO bookDTO)
        {
            Book newBook = setBookPost(bookDTO);

           
            return await _bookLogic.AddBook(newBook);

        }

        public async Task<BookDTO> getBook(int bookId)
        {
            var book =  await _bookLogic.getBook(bookId);
            var destinations = mapper.Map<Book, BookDTO>(book);
            return destinations;
        }

        public async Task<IEnumerable<BookDTO>> getBooks()
        {
            var  books =  await _bookLogic.getBooks();
            var destinations = mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
            return destinations;

        }

        public async Task<IEnumerable<BookDTO>> getBooksFollowType(int typeId)
        {
            var booktype =  await _bookLogic.getBooksFollowType(typeId);


            // return destination.Books;
            return null;


            //List<Book> list = new List<Book>();

            //IEnumerable<Book> books = list;
            //return books;
        }

        public Book setBookPost(BookDTO bookDTO)
        {
            Book newBook = mapper.Map<Book>(bookDTO);
            return newBook;
        }

        public async Task<Book> updateBook(BookDTO bookDTO)
        {
            Book newBook = setBookPost(bookDTO);
           return  await _bookLogic.UpdateBook(newBook);
         
        }
    }
}
