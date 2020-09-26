using BudgetManagement.Domain.Exceptions;
using BudgetManagement.Shared.Event;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetManagement.Domain.Entities.Base
{
    public abstract class BaseDomainEventHandler<TId> : BaseDomain<TId>
    {
        public DateTime CreatedOn { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }

        #region Errors

        public IDictionary<string, string> Errors { get; } = new Dictionary<string, string>();

        protected void AddError(DomainException domainException)
        {
            if (Errors.ContainsKey(domainException.ErrorCode))
            {
                Errors[domainException.ErrorCode] = string.Join(" ", Errors[domainException.ErrorCode], domainException.Message);
                return;
            }

            Errors.Add(domainException.ErrorCode, domainException.Message);
        }

        #endregion

        #region Events

        private readonly IList<IEvent> _events = new List<IEvent>();

        protected void RegisterEvent(IEvent domainEvent)
        {
            if (_events.Any(evt => evt.EventTypeId == domainEvent.EventTypeId))
            {
                _events.Remove(_events.First(evt => evt.EventTypeId == domainEvent.EventTypeId));
            }

            _events.Add(domainEvent);
        }

        public IReadOnlyList<IEvent> Events => (IReadOnlyList<IEvent>)_events;

        #endregion

        public T Verify<T>(Func<bool> actionToVerify) where T : BaseDomainEventHandler<TId>
        {
            var genericClassType = typeof(T);
            var baseDomainClassType = GetType();

            if (genericClassType != baseDomainClassType)
            {
                throw new DomainTypeMismatchException(genericClassType, baseDomainClassType);
            }

            try
            {
                var changed = actionToVerify.Invoke();

                if (changed)
                {
                    RegisterEvent(GetEvent());
                    UpdatedOn = DateTime.UtcNow;
                }
            }

            catch (DomainException domainException)
            {
                AddError(domainException);
            }

            return (T)this;
        }

        protected T UpdateProperty<T>(string newValue, string propertyValue, Action<string> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return Verify<T>(() =>
            {
                if (newValue == null)
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(newValue))
                {
                    var changed = propertyValue != null;
                    setProperty(null);
                    postSetProperty?.Invoke();

                    return changed;
                }

                if (propertyValue == newValue)
                {
                    return false;
                }

                setProperty(newValue);
                postSetProperty?.Invoke();

                return true;
            });
        }

        protected T UpdateProperty<T, TType>(List<TType> newValue, List<TType> propertyValue, Action<List<TType>> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return Verify<T>(() =>
            {
                if (newValue == null)
                {
                    return false;
                }

                if (propertyValue?.Equals(newValue) == true)
                {
                    return false;
                }

                setProperty(newValue);
                postSetProperty?.Invoke();

                return true;
            });
        }

        protected T UpdateProperty<T>(int? newValue, int propertyValue, Action<int> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return UpdateProperty<T, int>(newValue, propertyValue, setProperty, postSetProperty);
        }

        protected T UpdateProperty<T>(long? newValue, long propertyValue, Action<long> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return UpdateProperty<T, long>(newValue, propertyValue, setProperty, postSetProperty);
        }

        protected T UpdateProperty<T>(decimal? newValue, decimal propertyValue, Action<decimal> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return UpdateProperty<T, decimal>(newValue, propertyValue, setProperty, postSetProperty);
        }

        protected T UpdateProperty<T>(bool? newValue, bool propertyValue, Action<bool> setProperty, Action postSetProperty = null) where T : BaseDomainEventHandler<TId>
        {
            return UpdateProperty<T, bool>(newValue, propertyValue, setProperty, postSetProperty);
        }

        private T UpdateProperty<T, TType>(TType? newValue, TType propertyValue, Action<TType> setProperty, Action postSetProperty = null)
            where T : BaseDomainEventHandler<TId>
            where TType : struct
        {
            return Verify<T>(() =>
            {
                if (!newValue.HasValue)
                {
                    return false;
                }

                if (propertyValue.Equals(newValue.Value))
                {
                    return false;
                }

                setProperty(newValue.Value);
                postSetProperty?.Invoke();

                return true;
            });
        }

        protected abstract IEvent GetEvent();
    }
}