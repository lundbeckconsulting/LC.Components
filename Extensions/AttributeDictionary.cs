/*
        @Date			: 14.07.2020
        @Author         : Stein Lundbeck
*/

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LundbeckConsulting.Components.Extensions
{
    public static class AttributeDictionary
    {
        /// <summary>
        /// Adds a attribute to the dictionary
        /// </summary>
        /// <param name="attr">Element to add</param>
        /// <returns>Dictionary with element added</returns>
        public static Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary Add(this Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary dict, TagHelperAttribute attr)
        {
            dict.Add(attr.Name, attr.Value.ToString());

            return dict;
        }

        /// <summary>
        /// Adds multiple attributes to the dictionary
        /// </summary>
        /// <param name="attributes">Elements to add</param>
        public static Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary Add(this Microsoft.AspNetCore.Mvc.ViewFeatures.AttributeDictionary dict, IDictionary<string, string> attributes)
        {
            foreach (KeyValuePair<string, string> att in attributes)
            {
                dict.Add(new TagHelperAttribute(att.Key, att.Value));
            }

            return dict;
        }
    }
}
