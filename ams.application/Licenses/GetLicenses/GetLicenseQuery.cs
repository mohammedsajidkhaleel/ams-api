using ams.application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Licenses.GetLicenses;

public sealed record GetLicenseQuery()
    :IQuery<IReadOnlyList<LicenseResponse>>
{
}
