using ams.application.Abstractions.Messaging;

namespace ams.application.Employees.GetNationalities;
public sealed record GetNationalityQuery()
    : IQuery<IReadOnlyList<NationalityResponse>>;
