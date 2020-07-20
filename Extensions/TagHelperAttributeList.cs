/*
        @Date			: 15.07.2020
        @Author         : Stein Lundbeck
*/

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LundbeckConsulting.Components.Extensions
{
    public static class TagHelperAttributeList
    {
        /// <summary>
        /// Returns a list of tag helper attributes as an enumerable containing KeyValuePair of name and value as string
        /// </summary>
        /// <param name="list">Elements to process</param>
        /// <returns>Tag helper attributes as KeyValuePair enumerable</returns>
        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList list)
        {
            ICollection<KeyValuePair<string, string>> result = new Collection<KeyValuePair<string, string>>();

            foreach (TagHelperAttribute attr in list)
            {
                result.Add(new KeyValuePair<string, string>(attr.Name, attr.Value.ToString()));
            }

            return result;
        }
    }
}
