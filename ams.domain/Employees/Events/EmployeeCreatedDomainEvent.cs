using ams.domain.Abstractions;

namespace ams.domain.Employees.Events;
public sealed record class EmployeeCreatedDomainEvent(Guid employeId)
    : IDomainEvent;
