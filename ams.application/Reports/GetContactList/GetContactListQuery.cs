using ams.application.Abstractions.Messaging;

namespace ams.application.Reports.GetContactList;

public sealed record GetContactListQuery()
    : IQuery<IEnumerable<ContactListResponse>>;
