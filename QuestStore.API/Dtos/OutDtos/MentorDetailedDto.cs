using System.Collections.Generic;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.OutDtos
{
    public class MentorDetailedDto : ResourceEntity
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<ClassroomBriefDto> Classrooms { get; set; }
    }
}
