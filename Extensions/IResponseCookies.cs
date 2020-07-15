/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class IResponseCookiesExtensions
    { 
        /// <summary>
        /// Sets the culture in cookies using the default name
        /// </summary>
        /// <param name="code">Culture code to set</param>
        public static void SetLocalizationCulture(this IResponseCookies cookies, string code = "nb-NO")
        {
            cookies.Append(CookieRequestCultureProvider.DefaultCookieName, code, new CookieOptions() { Expires = DateTimeOffset.Now.AddDays(30) });
        }
    }
}
