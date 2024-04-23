using ams.domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.domain.ItemReceipts.Events
{
    public sealed record ItemReceiptCreatedDomainEvent(Guid itemReceiptId) : IDomainEvent;
}
