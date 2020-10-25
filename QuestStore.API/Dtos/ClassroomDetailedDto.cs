using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos
{
    public class ClassroomDetailedDto : ResourceEntity
    {
        public ICollection<StudentBriefDto> Students { get; set; }
        public ICollection<MentorBriefDto> Mentors { get; set; }
    }
}
