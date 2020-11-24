using System.Collections.Generic;
using QuestStore.API.Dtos.Duplex;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.OutDtos
{
    public class MentorDetailedDto : ResourceDto
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ICollection<ClassroomBriefDto> Classrooms { get; set; }
    }
}
