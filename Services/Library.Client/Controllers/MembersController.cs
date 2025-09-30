using Library.Client.Managers.Members;
using Library.Client.Models.Members;
using Microsoft.AspNetCore.Mvc;

namespace Library.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberManager _memberManager;

        public MembersController(IMemberManager memberManager)
        {
            _memberManager = memberManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] AddMemberRequest request)
        {
            var result = await _memberManager.AddMemberAsync(request);
            return StatusCode(result.status_code, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var result = await _memberManager.GetMembersAsync();
            return StatusCode(result.status_code, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var result = await _memberManager.GetMemberByIdAsync(id);
            return StatusCode(result.status_code, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var result = await _memberManager.DeleteMemberAsync(id);
            return StatusCode(result.status_code, result);
        }
    }
}
