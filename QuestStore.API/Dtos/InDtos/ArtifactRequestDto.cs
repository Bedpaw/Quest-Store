using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.InDtos
{
    public class ArtifactRequestDto : ResourceEntity
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
    }
}
