using Library.Client.Constants;
using Library.Client.Models.Members;
using Library.Client.Repositories.Member;
using Serilog;
using System.Net;

namespace Library.Client.Managers.Members
{
    public class MemberManager: IMemberManager
    {
        private readonly IMemberRepository _memberRepository;

        public MemberManager(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<ResponseResult<AddMemberResponse>> AddMemberAsync(AddMemberRequest member)
        {
            try
            {
                var result = await _memberRepository.CreateMemberAsync(member);
                if (result.success)
                    return result;

                return new ResponseResult<AddMemberResponse>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.InternalServerError,
                    message = StaticMessages.SomethingWentWrong
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(AddMemberAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<List<Member>>> GetMembersAsync()
        {
            try
            {
                var members = await _memberRepository.GetAllMembersAsync();
                var memberList = members.ToList();

                if (memberList.Count > 0)
                {
                    return new ResponseResult<List<Member>>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = memberList,
                        message = StaticMessages.MembersFound
                    };
                }

                return new ResponseResult<List<Member>>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    result = new List<Member>(),
                    message = StaticMessages.NoMembersFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(GetMembersAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<Member>> GetMemberByIdAsync(int memberId)
        {
            try
            {
                var member = await _memberRepository.GetMemberByIdAsync(memberId);
                if (member != null)
                {
                    return new ResponseResult<Member>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = member,
                        message = StaticMessages.MemberFound
                    };
                }

                return new ResponseResult<Member>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    message = StaticMessages.MemberNotFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(GetMemberByIdAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<bool>> DeleteMemberAsync(int memberId)
        {
            try
            {
                var deleted = await _memberRepository.DeleteMemberAsync(memberId);

                if (deleted)
                    return new ResponseResult<bool>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = true,
                        message = StaticMessages.MemberDeleted
                    };

                return new ResponseResult<bool>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    message = StaticMessages.MemberNotFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(DeleteMemberAsync), ex.Message);
                throw;
            }
        }
    }
}
