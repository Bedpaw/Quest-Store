using System.Collections.Generic;
using QuestStore.API.Dtos.Duplex;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.OutDtos
{
    public class ClassroomDetailedDto : ResourceDto
    {
        public ICollection<StudentBriefDto> Students { get; set; }
        public ICollection<MentorBriefDto> Mentors { get; set; }
    }
}
