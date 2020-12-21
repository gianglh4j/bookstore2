namespace BookStore.Models
{
    public partial class OrderBDetail
    {
        public int Amount { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }

        public virtual Book Book { get; set; }
        public virtual OrderB Order { get; set; }
    }

}
