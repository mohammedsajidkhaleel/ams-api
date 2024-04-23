using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.domain.Abstractions;
using Dapper;
using MediatR;

namespace ams.application.Employees.GetNationalities
{
    internal sealed class GetNationalityQueryHandler
        : IQueryHandler<GetNationalityQuery,
            IReadOnlyList<NationalityResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetNationalityQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<IReadOnlyList<NationalityResponse>>> IRequestHandler<GetNationalityQuery, Result<IReadOnlyList<NationalityResponse>>>.Handle(GetNationalityQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            select id,name from nationalities
            """;
            var employeeCategories = await connection
                .QueryAsync<NationalityResponse>(
                query
                );
            return employeeCategories.ToList();
        }
    }
}
