using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace BudgetManagement.Persistence.SqlServer
{
    public partial class BudgetManagementEntities
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly bool _enableAuditLog;

        public BudgetManagementEntities(bool enableAuditLog)
            : base("name=BudgetManagementEntities")
        {
            _enableAuditLog = enableAuditLog;
        }

        public override int SaveChanges()
        {
            return !_enableAuditLog ? base.SaveChanges() : AuditAndSaveChanges();
        }

        private int AuditAndSaveChanges()
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var objectContext = ((IObjectContextAdapter)this).ObjectContext;
                objectContext.SaveChanges(SaveOptions.DetectChangesBeforeSave);//Used to get ids from added records

                var auditLogs = GetAuditLogs();
                objectContext.AcceptAllChanges();

                AuditLogs.AddRange(auditLogs);

                try
                {
                    var num = objectContext.SaveChanges();
                    transactionScope.Complete();

                    return num;
                }

                catch (Exception ex)
                {
                    Log.Error("An error occurred trying to save audit logs.", ex);
                    throw;
                }
            }
        }

        private IEnumerable<AuditLog> GetAuditLogs()
        {
            var now = DateTime.Now;
            var entries = ChangeTracker.Entries().Where(o => o.State != EntityState.Unchanged && o.State != EntityState.Detached).ToList();
            var auditLogList = (from entry in entries
                                let state = entry.State.ToString()
                                let entityType = GetEntityType(entry)
                                let tableName = entityType.Name
                                let primaryKeyJson = GetPrimaryKeyJson(entry, entityType)
                                select new AuditLog
                                {
                                    EntityName = tableName,
                                    PrimaryKeyJson = primaryKeyJson,
                                    ChangeType = state,
                                    BeforeJson = entry.State == EntityState.Added
                                        ? "{ }"
                                        : GetAsJson(entry.OriginalValues),
                                    AfterJson = entry.State == EntityState.Deleted
                                        ? "{ }"
                                        : GetAsJson(entry.CurrentValues),
                                    //TODO: Figure out how to retrieve this
                                    UserId = 1,
                                    AuditDate = now
                                }).ToList();

            return auditLogList;
        }

        private static Type GetEntityType(DbEntityEntry entry)
        {
            var type = entry.Entity.GetType();

            if (type.BaseType != null && type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                type = type.BaseType;
            }

            return type;
        }

        private static string GetPrimaryKeyJson(DbEntityEntry entry, Type entityType)
        {
            var empty = string.Empty;

            foreach (var propertyInfo in entityType.GetProperties().Where(x => x.CustomAttributes.FirstOrDefault(y => y.AttributeType == typeof(KeyAttribute)) != null))
            {
                if (empty.Length > 0)
                {
                    empty += ", ";
                }

                var str = FormatValue((entry.State == EntityState.Deleted ? entry.OriginalValues : entry.CurrentValues)[propertyInfo.Name]);
                empty += $"\"{propertyInfo.Name}\": {str}";
            }
            return $"{{ {empty} }}";
        }

        private static string FormatValue(object value)
        {
            if (value == null)
            {
                return "null";
            }

            if (IsNumber(value))
            {
                return value.ToString();
            }

            switch (value)
            {
                case bool _:
                    {
                        return value.ToString().ToLowerInvariant();
                    }

                case DateTime dateTime:
                    {
                        return $"\"{dateTime:O}\"";
                    }

                default:
                    {
                        return $"\"{value}\"";
                    }
            }
        }

        private static bool IsNumber(object value)
        {
            int num;

            switch (value)
            {
                case sbyte _:
                case byte _:
                case short _:
                case ushort _:
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case float _:
                case double _:
                    {
                        num = 1;
                        break;
                    }

                default:
                    {
                        num = value is decimal ? 1 : 0;
                        break;
                    }
            }

            return num != 0;
        }

        private static string GetAsJson(DbPropertyValues values)
        {
            var content = string.Empty;

            if (values == null)
            {
                return $"{{ {content} }}";
            }

            foreach (var propertyName in values.PropertyNames)
            {
                if (content.Length > 0)
                {
                    content += ", ";
                }

                var str = FormatValue(values[propertyName]);
                content += $"\"{propertyName}\": {str}";
            }

            return $"{{ {content} }}";
        }
    }
}