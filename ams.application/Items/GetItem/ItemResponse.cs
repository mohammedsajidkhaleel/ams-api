using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Items.GetItem
{
    public sealed class ItemResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSubCategory { get; set; }
        public string Brand { get; set; }
    }
}
