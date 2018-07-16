using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Model.Module
{
    public class ModuleOutputModel
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public short Rank { get; set; }

        public bool? IsExpanded { get; set; }

        public List<ModuleOutputModel> Children { get; set; } = new List<ModuleOutputModel>();
    }
}
