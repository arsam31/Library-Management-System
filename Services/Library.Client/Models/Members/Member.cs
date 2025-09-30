namespace Library.Client.Models.Members
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsLibrarian { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
