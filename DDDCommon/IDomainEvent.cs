using System;

namespace DDDCommon
{
    public interface IDomainEvent
    {
        DateTime CreatedTime { get; set; }
    }
}