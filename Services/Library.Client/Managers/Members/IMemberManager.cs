using Library.Client.Models.Members;

namespace Library.Client.Managers.Members
{
    public interface IMemberManager
    {
        Task<ResponseResult<AddMemberResponse>> AddMemberAsync(AddMemberRequest member);
        Task<ResponseResult<List<Member>>> GetMembersAsync();
        Task<ResponseResult<Member>> GetMemberByIdAsync(int memberId);
        Task<ResponseResult<bool>> DeleteMemberAsync(int memberId);
    }
}
