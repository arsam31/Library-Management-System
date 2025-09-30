namespace Library.Client.Models.Library
{
    public class BorrowBookRequest
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }
}
