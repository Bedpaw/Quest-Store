using System.Collections.Generic;
using QuestStore.API.Dtos.Duplex;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.OutDtos
{
    public class StudentDetailedDto : ResourceDto
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Coins { get; set; }
        public ICollection<PurchasedArtifactBriefDto> Artifacts { get; set; }
        public ICollection<ClassroomBriefDto> Classrooms { get; set; }
        public ICollection<QuestBriefDto> PendingQuests { get; set; }
        public ICollection<QuestBriefDto> CompletedQuests { get; set; }
    }
}
