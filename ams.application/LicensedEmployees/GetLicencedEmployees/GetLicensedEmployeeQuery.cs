using ams.application.Abstractions.Messaging;
using ams.application.Models;

namespace ams.application.LicensedEmployees.GetLicencedEmployees;

public sealed record GetLicensedEmployeeQuery(Guid licenseId,int pageIndex, int pageSize)
    : IQuery<PaginatedResponse<LicensedEmployeeResponse>>
{
}
