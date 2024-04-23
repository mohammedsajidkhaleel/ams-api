

using ams.domain.Abstractions;

namespace ams.domain.Employees
{
    public sealed class Sponsor : Entity
    {
        public string Name { get; private set; }
        public DateTimeOffset CreationDateTime { get; private set; }
        private Sponsor()
        {
            
        }
        public Sponsor(Guid id, string sponsorName) : base(id)
        {
            Name = sponsorName;
            CreationDateTime = DateTimeOffset.UtcNow;
        }
    }
}
