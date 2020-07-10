/*
    @Date			              : 10.07.2020
    @Author                       : Stein Lundbeck
    @Description                  : The base type all entities handled by DBContextBase inherits
*/

using System;

namespace LundbeckConsulting.Components.Core.Data
{
    public interface IDataEntityBase
    {
        /// <summary>
        /// Entity id
        /// </summary>
        int Id { get; set; }
        
        /// <summary>
        /// Entity unique id
        /// </summary>
        Guid UId { get; set; }
        
        /// <summary>
        /// Date the entity was created
        /// </summary>
        DateTime DateCreated { get; set; }
    }

    public abstract class DataEntityBase : IDataEntityBase
    {
        public int Id { get; set; }
        public Guid UId { get; set; } = Guid.NewGuid();
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
