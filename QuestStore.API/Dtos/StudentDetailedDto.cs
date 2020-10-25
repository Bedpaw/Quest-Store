using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos
{
    public class StudentDetailedDto : ResourceEntity
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Coins { get; set; }
        public ICollection<ArtifactBriefDto> Artifacts { get; set; }
        public ICollection<ClassroomBriefDto> Classrooms { get; set; }
    }
}
