using System.Collections.Generic;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.OutDtos
{
    public class ClassroomDetailedDto : ResourceEntity
    {
        public ICollection<StudentBriefDto> Students { get; set; }
        public ICollection<MentorBriefDto> Mentors { get; set; }
    }
}
