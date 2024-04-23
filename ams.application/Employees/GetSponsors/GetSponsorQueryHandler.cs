using ams.application.Abstractions.Data;
using ams.application.Abstractions.Messaging;
using ams.application.Items.GetItemCategories;
using ams.domain.Abstractions;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Employees.GetSponsors
{
    internal sealed class GetSponsorQueryHandler
        : IQueryHandler<GetSponsorQuery,
            IReadOnlyList<SponsorResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetSponsorQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        async Task<Result<IReadOnlyList<SponsorResponse>>> IRequestHandler<GetSponsorQuery, Result<IReadOnlyList<SponsorResponse>>>.Handle(GetSponsorQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var query = """
            select id,name from sponsors
            """;
            var sponsors = await connection
                .QueryAsync<SponsorResponse>(
                query
                );
            return sponsors.ToList();
        }
    }
}
