using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.InDtos
{
    public class MentorRequestDto : ResourceEntity
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<int> ClassroomsIds { get; set; }
    }
}
