using System.Collections.Generic;

namespace MV.Common.Repository.Contracts.Core.Entities
{
    public interface IAggregateRoot
    {
        int Version { get; }
        IEnumerable<object> AppliedEvents { get; }
    }
}