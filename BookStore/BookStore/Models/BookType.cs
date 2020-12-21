using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class BookType
    {
        public BookType()
        {
            BookBookType = new HashSet<BookBookType>();
        }

        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }

        public virtual ICollection<BookBookType> BookBookType { get; set; }
    }
}
