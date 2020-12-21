using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.DTO;
using AutoMapper;
using BookStore.DomainLogic;

namespace BookStore.ApplicationLogic
{
    public interface IBookTypeApplicationLogic
    {
        Task<BookType> addBookType(BookTypeDTO bookTypeDTO);

        Task<BookType> updateBookType(BookTypeDTO bookTypeDTO);

      
        Task<IEnumerable<BookTypeDTO>> getBookTypes();

        Task<BookTypeDTO> getBookType(int bookTypeId);
    }
    public class BookTypeApplicationLogic : IBookTypeApplicationLogic
    {
        private readonly IMapper mapper;
        private readonly  IBookTypeLogic _bookTypeLogic;
        public BookTypeApplicationLogic(IMapper mapper, IBookTypeLogic _bookTypeLogic)
        {
            this.mapper = mapper;
            this._bookTypeLogic = _bookTypeLogic;
        }
        public async Task<BookType> addBookType(BookTypeDTO bookTypeDTO)
        {
            BookType newBookType = mapper.Map<BookTypeDTO, BookType>(bookTypeDTO);
            return await _bookTypeLogic.AddBookType(newBookType);
        }

        public async Task<BookTypeDTO> getBookType(int bookTypeId)
        {
            var booktype = await _bookTypeLogic.GetBookType(bookTypeId);
            var destinations = mapper.Map<BookType, BookTypeDTO>(booktype);
            return destinations;
        }

        public async Task<IEnumerable<BookTypeDTO>> getBookTypes()
        {
            var booktypes = await _bookTypeLogic.getBookTypes();
            var destinations = mapper.Map<IEnumerable<BookType>, IEnumerable<BookTypeDTO>>(booktypes);
            return destinations;
        }

        public async Task<BookType> updateBookType(BookTypeDTO bookTypeDTO)
        {
            BookType booktype = mapper.Map<BookType>(bookTypeDTO);
            return await _bookTypeLogic.UpdateBookType(booktype);
        }
    }
}
