/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System.Globalization;
using System.Threading;

namespace LundbeckConsulting.Components.Repos
{
    public interface IRepoBase
    {
        /// <summary>
        /// The culture used by current thread
        /// </summary>
        /// <returns>The current culture as a CultureInfo element</returns>
        CultureInfo CurrentCulture { get; }

        /// <summary>
        /// The ui culture used by current thread
        /// </summary>
        CultureInfo CurrentUICulture { get; }
    }

    /// <summary>
    /// Base class for repo's that doesn't support the Core framework
    /// </summary>
    public abstract class RepoBase : IRepoBase
    {
        public CultureInfo CurrentCulture { get { return Thread.CurrentThread.CurrentCulture; } }

        public CultureInfo CurrentUICulture { get { return Thread.CurrentThread.CurrentUICulture; } }
    }
}
