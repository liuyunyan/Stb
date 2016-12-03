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
using Stb.Api.Models.MessageViewModels;

namespace Stb.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Message")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer", Roles = "�ų�,����")]
    [ApiExceptionFilter]
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Appͨ�ã�δ����Ϣ����
        /// </summary>
        /// <param name="type">Required - ��Ϣ���ͣ�1-ƽ̨�µ����ų��ˣ���2-�ų��µ����೤�ˣ���3-�೤ǩ�����ų��ˣ���4-ʩ�����⣨�ų��ˣ�</param>
        /// <returns></returns>
        [HttpGet("Count")]
        public async Task<ApiOutput<int>> GetMsgCountAsync([RequiredFromQuery]int type)
        {
            return new ApiOutput<int>(await _messageService.GetMessageCountAsync(this.UserId(), type));
        }

        /// <summary>
        /// Appͨ�ã���Ϣ�б�
        /// </summary>
        /// <param name="type">Required - ��Ϣ���ͣ�1-ƽ̨�µ����ų��ˣ���2-�ų��µ����೤�ˣ���3-�೤ǩ�����ų��ˣ���4-ʩ�����⣨�ų��ˣ�</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiOutput<List<MessageData>>> GetMessageAsync([RequiredFromQuery]int type)
        {
            return new ApiOutput<List<MessageData>>(await _messageService.GetMessageAsync(this.UserId(), type));
        }

        /// <summary>
        /// Appͨ�ã�������Ϣ�Ѷ�
        /// </summary>
        /// <param name="msgId">Required - ��ϢId</param>
        /// <returns></returns>
        [HttpGet("Read")]
        public async Task<ApiOutput<bool>> SetMessageReadAsync([RequiredFromQuery]int msgId)
        {
            return new ApiOutput<bool>(await _messageService.SetMessageReadAsync(msgId, this.UserId()));
        }
    }
}