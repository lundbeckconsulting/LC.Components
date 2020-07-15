/*
    @Date			 : 15.07.2020
    @Author			 : Stein Lundbeck
*/

using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace LundbeckConsulting.Components
{
    public interface IIPAddressCustom
    {
        /// <summary>
        /// Part one of address
        /// </summary>
        int PartOne { get; set; }

        /// <summary>
        /// Part two of address
        /// </summary>
        int PartTwo { get; set; }

        /// <summary>
        /// Part three of address
        /// </summary>
        int PartThree { get; set; }

        /// <summary>
        /// Part four of address
        /// </summary>
        int PartFour { get; set; }

        /// <summary>
        /// Parsed object as IP address
        /// </summary>
        IPAddress Address { get; }

        /// <summary>
        /// String that combines all address parts
        /// </summary>
        /// <returns>IP address string</returns>
        string ToString();
    }

    /// <summary>
    /// Custom IP address element based on either string or http context
    /// </summary>
    public class IPAddressCustom : IIPAddressCustom
    {
        /// <summary>
        /// Current IP address based on IP host entry
        /// </summary>
        public IPAddressCustom() 
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            Parse(host.AddressList[1].ToString());
        }

        /// <summary>
        /// Current IP address based on address string
        /// </summary>
        /// <param name="address">IP address</param>
        public IPAddressCustom(string address)
        {
            Parse(address);
        }

        /// <summary>
        /// Current IP address based on current http context
        /// </summary>
        /// <param name="context"></param>
        public IPAddressCustom(IHttpContextAccessor context)
        {
            Parse(context.HttpContext.Connection.RemoteIpAddress.ToString());
        }

        private void Parse(string address)
        {
            string[] parts = address.Split(new char[] { '.' });

            if (parts.Length.Equals(4))
            {
                this.PartOne = int.Parse(parts[0]);
                this.PartTwo = int.Parse(parts[1]);
                this.PartThree = int.Parse(parts[2]);
                this.PartFour = int.Parse(parts[3]);
            }
            else
            {
                throw new ArgumentException("String is not recognized as an IP address");
            }
        }

        public int PartOne { get; set; }
        public int PartTwo { get; set; }
        public int PartThree { get; set; }
        public int PartFour { get; set; }       
        public IPAddress Address => IPAddress.Parse(this.ToString());
        public new string ToString() => $"{this.PartOne}.{this.PartTwo}.{this.PartThree}.{this.PartFour}";
    }
}
