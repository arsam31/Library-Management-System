using Library.Client.Constants;
using Library.Client.Models.Members;
using System.Data;
using System.Data.SqlClient;

namespace Library.Client.Repositories.Member
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ResponseResult<AddMemberResponse>> CreateMemberAsync(AddMemberRequest member)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_AddMember", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", member.Name);
            command.Parameters.AddWithValue("@Email", member.Email);
            command.Parameters.AddWithValue("@IsLibrarian", member.IsLibrarian);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();

            return new ResponseResult<AddMemberResponse>
            {
                success = true,
                status_code = 200,
                result = new AddMemberResponse { MemberId = Convert.ToInt32(result) },
                message = StaticMessages.MemberAdded
            };
        }

        public async Task<IEnumerable<Models.Members.Member>> GetAllMembersAsync()
        {
            var members = new List<Models.Members.Member>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_GetAllMembers", connection);
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                members.Add(new Models.Members.Member
                {
                    MemberId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    IsLibrarian = reader.GetBoolean(3),
                    CreatedDate = reader.GetDateTime(4)
                });
            }
            return members;
        }

        public async Task<Models.Members.Member?> GetMemberByIdAsync(int memberId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_GetMemberById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MemberId", memberId);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Models.Members.Member
                {
                    MemberId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    IsLibrarian = reader.GetBoolean(3),
                    CreatedDate = reader.GetDateTime(4)
                };
            }
            return null;
        }

        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_DeleteMember", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MemberId", memberId);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result) > 0;
        }

    }
}
