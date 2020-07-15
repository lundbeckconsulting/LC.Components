/*
    @Date			              : 15.07.2020
    @Author                       : Stein Lundbeck
*/

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace LundbeckConsulting.Components.Extensions
{
    public static class TagBuilderExtensions
    {
        /// <summary>
        /// Adds a range of values to the tag's class attribute
        /// </summary>
        /// <param name="vals">Values to add</param>
        public static TagBuilder AddCssClassRange(this TagBuilder tag, params string[] vals)
        {
            foreach(string val in vals)
            {
                tag.AddCssClass(val);
            }

            return tag;
        }

        /// <summary>
        /// Deletes attributes if it exists and adds a new attribute with name same name with specified value
        /// </summary>
        /// <param name="name">Name of attribute</param>
        /// <param name="value">Attribute value</param>
        public static TagBuilder SetAttribute(this TagBuilder tag, string name, string value)
        {
            tag.MergeAttribute(name, value, true);

            return tag;
        }

        /// <summary>
        /// Deletes attributes if it exists and adds specified attribute
        /// </summary>
        /// <param name="attribute">Element to set</param>
        public static TagBuilder SetAttribute(this TagBuilder tag, TagHelperAttribute attribute)
        {
            return tag.SetAttribute(attribute.Name, attribute.Value.ToString());
        }

        /// <summary>
        /// Merge an existing attribute with specified attribute element
        /// </summary>
        /// <param name="attribute">Element to merge</param>
        /// <param name="replace">If true the existing attribute is replaced. Default is false</param>
        public static TagBuilder MergeAttribute(this TagBuilder tag, TagHelperAttribute attribute, bool replace = false)
        {
            string val = attribute.Value.ToString();

            if (!replace && tag.AttributeExists(attribute))
            {
                val = $"{val} {tag.Attributes.GetValueOrDefault(attribute.Name)}";
            }

            tag.MergeAttribute(attribute.Name, val, true);

            return tag;
        }

        /// <summary>
        /// Returns true if an attribute with equal name as specified attribute
        /// </summary>
        /// <param name="attribute">Element with name to verify</param>
        /// <returns>True if element with equal name exists</returns>
        public static bool AttributeExists(this TagBuilder tag, TagHelperAttribute attribute)
        {
            return tag.AttributeExists(attribute.Name);
        }

        /// <summary>
        /// Returns true if an attribute with name equal to specified name exists
        /// </summary>
        /// <param name="name">Name of attribute</param>
        /// <returns>True if element with equal name exists</returns>
        public static bool AttributeExists(this TagBuilder tag, string name)
        {
            return tag.Attributes.ContainsKey(name);
        }
    }
}
