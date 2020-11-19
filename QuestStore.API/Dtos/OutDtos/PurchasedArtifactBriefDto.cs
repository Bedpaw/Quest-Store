using QuestStore.Core.Enums;

namespace QuestStore.API.Dtos.OutDtos
{
    public class PurchasedArtifactBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchasedQuantity { get; set; }
    }
}