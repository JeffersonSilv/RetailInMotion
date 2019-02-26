using System;

namespace RetailInMotion.Domain.Abstract
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
