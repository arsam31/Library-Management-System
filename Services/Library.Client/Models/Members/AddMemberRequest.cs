namespace Library.Client.Models.Members
{
    public class AddMemberRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsLibrarian { get; set; }
    }
}
