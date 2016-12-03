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
    [Route("api/Worker/Order")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "����")]
    [ApiExceptionFilter]
    public class WorkerOrderController : Controller
    {
        private readonly OrderService _orderService;

        public WorkerOrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// App�೤�ˣ������б�
        /// </summary>
        /// <remarks>
        /// ֻ����״̬Ϊ1��ʩ��״̬���Ĺ���
        /// Ŀǰkeyֻ�Թ����Ž��в�ѯ
        /// </remarks>
        /// <param name="key">Optional - ������ѯ�ؼ���</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiOutput<List<WorkerOrderData>>> GetOrderAsync([FromQuery]string key = null)
        {
            return new ApiOutput<List<WorkerOrderData>>(await _orderService.GetWorkerOrdersAsync(this.UserId(), key));
        }

        /// <summary>
        /// App�೤�ˣ����ܹ���
        /// </summary>
        /// <param name="orderId">����Id</param>
        /// <returns></returns>
        [HttpGet("Accept")]
        public async Task<ApiOutput<bool>> AcceptOrderAsync([FromQuery]string orderId)
        {
            return new ApiOutput<bool>(await _orderService.WorkerAcceptOrderAsync(this.UserId(), orderId));
        }

        /// <summary>
        /// App�೤�ˣ��೤ǩ��
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <param name="pics">Required - ǩ����Ƭ�����ŷָ�</param>
        /// <param name="location">Required - ǩ���ص����� lng,lat</param>
        /// <param name="address">Required - ǩ���ص��ַ</param>
        /// <returns></returns>
        [HttpGet("SignIn")]
        public async Task<ApiOutput<bool>> SignInAsync([RequiredFromQuery]string orderId, [RequiredFromQuery]string pics, [RequiredFromQuery]string location, [RequiredFromQuery]string address)
        {
            return new ApiOutput<bool>(await _orderService.WorkerSignInAsync(this.UserId(), orderId, pics, location, address, true));
        }

        /// <summary>
        /// App�೤�ˣ��೤ǩ��
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <param name="pics">Required - ǩ����Ƭ�����ŷָ�</param>
        /// <param name="location">Required - ǩ���ص����� lng,lat</param>
        /// <param name="address">Required - ǩ���ص��ַ</param>
        /// <returns></returns>
        [HttpGet("SignOut")]
        public async Task<ApiOutput<bool>> SignOutAsync([RequiredFromQuery]string orderId, [RequiredFromQuery]string pics, [RequiredFromQuery]string location, [RequiredFromQuery]string address)
        {
            return new ApiOutput<bool>(await _orderService.WorkerSignInAsync(this.UserId(), orderId, pics, location, address, false));
        }

        /// <summary>
        /// App�೤�ˣ�����ǩ��״̬
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("SignState")]
        public async Task<ApiOutput<int>> SignStateAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<int>(await _orderService.WorkerSignStateAsync(this.UserId(), orderId));
        }

        /// <summary>
        /// App�೤�ˣ�����ǩ����Ϣ
        /// </summary>
        /// <param name="orderId">Required - ����Id</param>
        /// <returns></returns>
        [HttpGet("Signments")]
        public async Task<ApiOutput<WorkerSignmentData>> SignmentsAsync([RequiredFromQuery]string orderId)
        {
            return new ApiOutput<WorkerSignmentData>(await _orderService.GetWorkerSignmentsAsync(orderId, this.UserId()));
        }

        /// <summary>
        /// App�೤�ˣ���¼����
        /// </summary>
        /// <param name="orderId">Required - ����id</param>
        /// <param name="issueType">Required - �������ͣ�1-������⣻2-ҵ��Ҫ��3-�ֳ��������߱�ʩ��������4-���ɿ���</param>
        /// <param name="solutionType">Required - ����������ͣ�1-����ʩ����2-�Ƴ�ʩ����3-�޸���ƣ�4-�����豸�ͺ�</param>
        /// <param name="pics">Optional - ͼƬ���ӣ����ŷָ�</param>
        /// <param name="audios">Optional - ¼�����ӣ����ŷָ�</param>
        /// <returns></returns>
        [HttpGet("ReportIssue")]
        public async Task<ApiOutput<bool>> ReportIssueAsync([RequiredFromQuery]string orderId, [RequiredFromQuery]int issueType, [RequiredFromQuery]int solutionType, [FromQuery]string pics, [FromQuery] string audios)
        {
            return new ApiOutput<bool>(await _orderService.WorkerReportIssueAsync(this.UserId(), orderId, issueType, solutionType, pics, audios));
        }

    }
}