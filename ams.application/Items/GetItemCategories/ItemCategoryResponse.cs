using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.application.Items.GetItemCategories
{
    public sealed class ItemCategoryResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public string ParentCategory { get; set; }
    }
}
