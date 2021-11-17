/*
    @Date			: 13.07.2021
    @Author         : Stein Lundbeck
*/

using System.Reflection;

namespace LundbeckConsulting.Components.Extensions.Model
{
    public interface IObjectPropertyModel
    {
        void AddInfo(PropertyInfo info);
        PropertyInfo Info { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    }

    public class ObjectPropertyModel : IObjectPropertyModel
    {
        public void AddInfo(PropertyInfo info)
        {
            this.Info = info;
            this.Name = info.Name;
            this.Value = info.GetValue(info, null).ToString();
        }

        public PropertyInfo Info { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
