﻿using Stb.Data.Models;
using Stb.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stb.Api.Models.OrderViewModels
{
    public class SignmentData
    {
        /// <summary>
        /// 签到用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 签到用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 签到、签退时间，web用
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 签到、签退时间
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// 签到、签退地点坐标
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 签到地点坐标静态图url
        /// </summary>
        public string LocationUrl { get; set; }

        /// <summary>
        /// 签到地点地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 签到照片，逗号分隔
        /// </summary>
        public string Pics { get; set; }

        /// <summary>
        /// 签到还是签退：true-签到；false-签退
        /// </summary>
        public bool InOut { get; set; }

        public SignmentData(Signment signment)
        {
            UserId = signment.EndUserId;
            UserName = signment.EndUser?.Name;
            DateTime = signment.Time;
            Time = signment.Time.ToUnixSeconds();
            Location = signment.Location;
            LocationUrl = $"http://restapi.amap.com/v3/staticmap?location={signment.Location}&zoom=12&size=300*200&markers=mid,,:{signment.Location}&key=1ff97f3d9068e5e12e21f3c34480096a";
            Address = signment.Address;
            Pics = signment.Pics;
            InOut = signment.InOut;
        }
    }
}