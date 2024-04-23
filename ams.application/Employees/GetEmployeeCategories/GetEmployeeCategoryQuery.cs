using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetEmployeeCategories;
public sealed record GetEmployeeCategoryQuery()
    : IQuery<IReadOnlyList<EmployeeCategoryResponse>>;
