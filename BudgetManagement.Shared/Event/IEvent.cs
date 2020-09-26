using System;

namespace BudgetManagement.Shared.Event
{
    public interface IEvent
    {
        Guid EventTypeId { get; }
        Guid MessageId { get; }
        Guid CorrelationId { get; }

        IEvent SetCorrelationId(Guid correlationId);
        IEvent SetMessageId(Guid messageId);
    }
}