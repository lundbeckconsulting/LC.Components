/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace LundbeckConsulting.Components.Extensions
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Generates an URI as string based on current HttpRequest
        /// </summary>
        /// <param name="request">Request used to populate URI</param>
        /// <returns>URI generated from current request</returns>
        public static Uri ToUri(this HttpRequest request)
        {
            StringBuilder url = new StringBuilder();
            url.Append(request.Scheme + "://");
            url.Append(request.Host);

            if (request.PathBase.HasValue)
            {
                url.Append(request.PathBase.Value);
            }

            if (request.Path.HasValue)
            {
                url.Append(request.Path.Value);
            }

            if (request.QueryString.HasValue)
            {
                url.Append(request.QueryString.Value);
            }

            return new Uri(url.ToString());
        }
    }
}
