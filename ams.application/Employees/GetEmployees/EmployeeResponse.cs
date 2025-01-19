namespace ams.application.Employees.GetEmployees;
public sealed class EmployeeResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public Guid? SponsorId { get; set; }
    public Guid? ParentDepartmentId { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? EmployeeCategoryId { get; set; }
    public Guid? NationalityId { get; set; }
    public Guid? EmployeePositionId { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Doj { get; set; }
    public string SponsorName { get; set; }
    public string DepartmentName { get; set; }
    public string EmployeeCategoryName { get; set; }
    public string NationalityName { get; set; }
    public string EmployeePositionName { get; set; }
    public string ProjectName { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
}
