/*
    @Date			              : 15.07.2020
    @Author                       : Stein Lundbeck
*/

using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ViewDataDictionary
    {
        /// <summary>
        /// Value to element with key name. Throw exception of element not found or element value not equal to TElement type
        /// </summary>
        /// <typeparam name="TElement">The type of element expected from the collection</typeparam>
        /// <param name="name">Name of key</param>
        /// <returns>Value from ViewDataDictionary that belongs to defined name</returns>
        public static TElement GetValue<TElement>(this Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary view, string name)
        {
            TElement result = default;

            if (!view.ContainsKey(name))
            {
                throw new ArgumentOutOfRangeException($"View doesn't have a key equal \"{name}\"");
            }
            else
            {
                if (view.TryGetValue(name, out object val))
                {
                    if (val is TElement)
                    {
                        result = (TElement)val;
                    }
                    else
                    {
                        throw new ArgumentException($"Value is not of type \"{nameof(TElement)}\"");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Value to element with equal index. Throw exception of element not found or element value not equal to TElement type
        /// </summary>
        /// <typeparam name="TElement">The type of element expected from the collection</typeparam>
        /// <param name="index">Index of value</param>
        /// <returns>Value from ViewDataDictionary that belongs to element with suppled index</returns>
        public static TElement GetValue<TElement>(this Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary view, int index)
        {
            TElement result = default;

            if (index > view.Count)
            {
                throw new ArgumentOutOfRangeException($"No value at index {index}");
            }
            else
            {
                int i = 0;

                foreach(object val in view.Values)
                {
                    if (i == index)
                    {
                        if (val is TElement)
                        {
                            result = (TElement)val;
                        }
                        else
                        {
                            throw new ArgumentException($"Value is not of type \"{nameof(TElement)}\"");
                        }
                    }

                    i++;
                }
            }

            return result;
        }
    }
}
