using System.Collections.Generic;

namespace Focus.Application.Dtos.Module
{
    public class ModuleDto
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public short Rank { get; set; }

        public bool? IsExpanded { get; set; }

        public List<ModuleDto> Children { get; set; } = new List<ModuleDto>();
    }
}
