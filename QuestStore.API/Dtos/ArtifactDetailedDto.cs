using System.Collections.Generic;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos
{
    public class ArtifactDetailedDto : ResourceEntity
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public ICollection<StudentBriefDto> Students { get; set; }
    }
}
