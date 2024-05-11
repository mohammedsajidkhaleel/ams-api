using ams.domain.Abstractions;
using ams.domain.Employees.Events;
namespace ams.domain.Employees;
public sealed class Employee : Entity
{
    public EmployeeCode Code { get; private set; }
    public EmployeeName Name { get; private set; }
    public Guid? SponsorId { get; private set; }
    public Guid? DepartmentId { get; private set; }
    public Guid? EmployeeCategoryId { get; private set; }
    public Guid? NationalityId { get; private set; }
    public Guid? EmployeePositionId { get; private set; }
    public Mobile Mobile { get; private set; }
    public Email Email { get; set; }
    public DateOnly? DOJ { get; set; }
    public Guid? ProjectId { get; set; }
    public DateTimeOffset CreationDateTime { get; private set; }
    public EmployeeStatus Status { get; private set; }
    private Employee()
    {

    }
    public Employee(Guid id,
        EmployeeCode code,
        EmployeeName name,
        Guid? sponsorId,
        Guid? departmentId,
        Guid? employeeCategoryId,
        Guid? nationalityId,
        Guid? employeePositionId,
        Mobile mobile,
        Email email,
        DateOnly dateOfJoining,
        Guid? projectId,
        EmployeeStatus employeeStatus) : base(id)
    {
        Code = code;
        Name = name;
        SponsorId = sponsorId;
        DepartmentId = departmentId;
        EmployeeCategoryId = employeeCategoryId;
        NationalityId = nationalityId;
        EmployeePositionId = employeePositionId;
        Mobile = mobile;
        Email = email;
        DOJ = dateOfJoining;
        ProjectId = projectId;
        CreationDateTime = DateTimeOffset.UtcNow;
        Status = employeeStatus;
    }

    public static Employee CreateEmployee(EmployeeCode code,
        EmployeeName name,
        Guid? sponsorId,
        Guid? departmentId,
        Guid? employeeCategoryId,
        Guid? nationalityId,
        Guid? employeePositionId,
        Mobile mobile,
        Email email,
        DateOnly doj,
        Guid? projectId,
        EmployeeStatus status
        )
    {
        var employee = new Employee(
            Guid.NewGuid(),
            code,
            name,
            sponsorId,
            departmentId,
            employeeCategoryId,
            nationalityId,
            employeePositionId,
            mobile,
            email,
            doj,
            projectId,
            status
            );
        employee.RaiseDomainEvent(new EmployeeCreatedDomainEvent(employee.Id));
        return employee;
    }

    public static Employee EditEmployee(
    Employee employee,
    EmployeeCode code,
    EmployeeName name,
    Guid? sponsorId,
    Guid? departmentId,
    Guid? employeeCategoryId,
    Guid? nationalityId,
    Guid? employeePositionId,
    Mobile mobile,
    Email email,
    DateOnly doj,
    Guid? projectId,
    EmployeeStatus status
    )
    {
        employee.Code = code;
        employee.Name = name;
        employee.SponsorId = sponsorId;
        employee.DepartmentId = departmentId;
        employee.EmployeeCategoryId = employeeCategoryId;
        employee.NationalityId = nationalityId;
        employee.EmployeePositionId = employeePositionId;
        employee.Mobile = mobile;
        employee.Email = email;
        employee.DOJ = doj;
        employee.ProjectId = projectId;
        employee.Status = status;
        employee.RaiseDomainEvent(new EmployeeCreatedDomainEvent(employee.Id));
        return employee;
    }
}

