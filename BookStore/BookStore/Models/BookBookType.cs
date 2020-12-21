namespace BookStore.Models
{
    public partial class BookBookType
    {
        public int BookId { get; set; }
        public int BookTypeId { get; set; }

        public virtual Book Book { get; set; }
        public virtual BookType BookType { get; set; }
    }
}
