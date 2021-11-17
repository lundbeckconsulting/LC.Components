/*
    @Date			 : 07.08.2021
    @Author			 : Stein Lundbeck
*/

using System;
using System.Linq;
using System.Reflection;

namespace LundbeckConsulting.Components.Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns all types within a namespace
        /// </summary>
        /// <param name="assembly">Assembly to process</param>
        /// <param name="nameSpace">Name of namespace</param>
        /// <returns>Types withing namespace</returns>
        public static Type[] GetTypes(this Assembly assembly, string nameSpace) => assembly.GetTypes()
            .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
            .ToArray();
    }
}
