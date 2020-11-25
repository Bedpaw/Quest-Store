using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Enums;
using QuestStore.API.Dtos.Duplex;

namespace QuestStore.API.Dtos.OutDtos
{
    public class QuestWithStudentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentBriefDto> Students { get; set; }

    }
}
