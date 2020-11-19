using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.API.Dtos.Duplex
{
    public class ArtifactDetailedDto : ResourceDto
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public ArtifactType Type { get; set; }
        //public ICollection<StudentBriefDto> Students { get; set; }
    }
}
