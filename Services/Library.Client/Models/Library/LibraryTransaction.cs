namespace Library.Client.Models.Library
{
    public class LibraryTransaction
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
