using RetailInMotion.Domain.Abstract;
using System;

namespace RetailInMotion.Domain
{
    public class Product : IEntity
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
