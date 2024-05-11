using ams.domain.Abstractions;

namespace ams.domain.Employees.Events;
public sealed record class EmployeeUpdatedDomainEvent(Guid employeId)
    : IDomainEvent;
