﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaiwellFuture.Services;

namespace HaiwellFuture.Middlewares
{
    public class RequestIPMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IRequestIPRecord requestIPRecord;

        public RequestIPMiddleware(RequestDelegate next, IRequestIPRecord requestIPRecord)
        {
            this.next = next;
            this.requestIPRecord = requestIPRecord;
        }
        public async Task Invoke(HttpContext context)
        {
            string userAgent = context.Request.Headers["User-Agent"];

            string ip = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            IpRecord ipRecord = new IpRecord
            {
                Ip = ip,
                DateTime = DateTime.Now,
                UserAgent = userAgent
            };
            await this.requestIPRecord.Add(ipRecord);
            await this.next.Invoke(context);
        }
    }
}
