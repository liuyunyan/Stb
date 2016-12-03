using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Stb.Api.Models.OrderViewModels;
using Stb.Api.Models;
using Stb.Api.Services;

namespace Stb.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Platoon/Order")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "�ų�")]
    [ApiExceptionFilter]
    public class PlatoonOrderController : Controller
    {
        private readonly OrderService _orderService;

        public PlatoonOrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// App�ų��ˣ������б�
        /// </summary>
        /// <remarks>
        /// ֻ����״̬Ϊ0��׼��״̬����1��ʩ��״̬���Ĺ���
        /// Ŀǰkeyֻ�Թ����Ž��в�ѯ
        /// </remarks>
        /// <param name="key">Optional - ������ѯ�ؼ���</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiOutput<List<PlatoonOrderData>>> GetOrderAsync([FromQuery]string key = null)
        {
            return new ApiOutput<List<PlatoonOrderData>>(await _orderService.GetPlatoonOrdersAsync(this.UserId(), key));
        }

        /// <summary>
        /// App�ų��ˣ��ų�ǩ��
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <param name="pics">Required - ǩ����Ƭ�����ŷָ�</param>
        /// <param name="location">Required - ǩ���ص����� lng,lat</param>
        /// <param name="address">Required - ǩ���ص��ַ</param>
        /// <returns></returns>
        [HttpGet("SignIn")]
        public async Task<ApiOutput<bool>> SignInAsync([RequiredFromQuery]string orderId, [RequiredFromQuery]string pics, [RequiredFromQuery]string location, [RequiredFromQuery]string address)
        {
            return new ApiOutput<bool>(await _orderService.PlatoonSignInAsync(this.UserId(), orderId, pics, location, address));
        }

        /// <summary>
        /// App�ų��ˣ��ų����մ˹����Ƿ���ǩ��
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("IsSignIn")]
        public async Task<ApiOutput<bool>> IsSignInAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<bool>(await _orderService.IsPlatoonSignInAsync(this.UserId(), orderId));
        }

        /// <summary>
        /// App�ų��ˣ���������
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("Progress")]
        public async Task<ApiOutput<ProgressData>> GetOrderProgressAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<ProgressData>(await _orderService.GetOrderProgressAsync(orderId));
        }

        /// <summary>
        /// App�ų��ˣ�����ǩ���б�
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("WorkerSignments")]
        public async Task<ApiOutput<List<SignmentData>>> GetWorkerSignmentsAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<List<SignmentData>>(await _orderService.GetWorkerSignmentsAsync(orderId));
        }

        /// <summary>
        /// App�ų��ˣ����˼�¼�����б�
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("Issues")]
        public async Task<ApiOutput<List<IssueData>>>GetOrderIssueAsync([RequiredFromQuery] string orderId)
        {
            return new ApiOutput<List<IssueData>>(await _orderService.GetIssueAsync(orderId));
        }

        /// <summary>
        /// App�ų��ˣ������ų�ǩ���б�
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("Signments")]
        public async Task<ApiOutput<List<SignmentData>>> GetPlatoonSignmentAsync([RequiredFromQuery] string orderId)
        {
            return new ApiOutput<List<SignmentData>>(await _orderService.GetPlatoonSignmentAsync(orderId));
        }


        /// <summary>
        /// App�ų��ˣ����ʩ��
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("Finish")]
        public async Task<ApiOutput<bool>> FinishOrderWorkAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<bool>(await _orderService.FinishOrderWorkAsync(orderId, this.UserId()));
        }


    }
}