using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stb.Data;
using Stb.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
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
        /// <param name="key">ģ����ѯ</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiOutput<List<OrderData>>> GetOrder([FromQuery]string key = null)
        {
            string userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            return new ApiOutput<List<OrderData>>(await _orderService.GetWorkerOrdersAsync(userId, key));
        }

    }
}