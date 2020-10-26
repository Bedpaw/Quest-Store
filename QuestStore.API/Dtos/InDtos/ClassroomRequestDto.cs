using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.API.Dtos.InDtos
{
    public class ClassroomRequestDto
    {
        public ICollection<int> StudentsIds { get; set; }
        public ICollection<int> MentorsIds { get; set; }
    }
}
