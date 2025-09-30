namespace Library.Client.Models.Book
{
    public class AddBookRequest
    {
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int AddedByUserId { get; set; }
    }
}
