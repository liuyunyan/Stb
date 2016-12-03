using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Stb.Api.Services;
using Stb.Api.Models;

namespace Stb.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    [ApiExceptionFilter]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Appͨ�ã��ϱ�����ID
        /// </summary>
        /// <param name="pushId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("updatePushId")]
        public async Task<ApiOutput<bool>> UpdatePushIdAsync([RequiredFromQuery]string pushId)
        {
            return new ApiOutput<bool>(await _userService.UpdatePushIdAsync(User, pushId));
        }

        /// <summary>
        /// Appͨ�ã������û�ͷ��
        /// </summary>
        /// <param name="portrait">Required - ͷ��url</param>
        /// <returns></returns>
        [HttpGet("updatePortrait")]
        public async Task<ApiOutput<bool>> UpdatePortraitAsync([RequiredFromQuery]string portrait)
        {
            return new ApiOutput<bool>(await _userService.UpdatePortraitAsync(User, portrait));
        }
    }
}