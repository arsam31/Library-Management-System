using Library.Client.Models.Members;

namespace Library.Client.Repositories.Member
{
    public interface IMemberRepository
    {
        Task<ResponseResult<AddMemberResponse>> CreateMemberAsync(AddMemberRequest member);
        Task<IEnumerable<Models.Members.Member>> GetAllMembersAsync();
        Task<Models.Members.Member?> GetMemberByIdAsync(int memberId);
        Task<bool> DeleteMemberAsync(int memberId);
    }
}
