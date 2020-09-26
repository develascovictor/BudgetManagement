using BudgetManagement.Shared.Event;
using System;
using System.Collections.Generic;

namespace BudgetManagement.Shared.EventHandling.Interfaces
{
    public interface IEventDispatcher
    {
        void Dispatch(IEvent domainEvent);
        void Dispatch(IEvent domainEvent, Guid correlationId);
        void Dispatch(IReadOnlyList<IEvent> domainEvents);
        void Dispatch(IReadOnlyList<IEvent> domainEvents, Guid correlationId);
    }
}