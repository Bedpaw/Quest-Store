using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Enums;

namespace QuestStore.API.Dtos.OutDtos
{
    public class StudentQuestBriefDto
    {
        public int StudentId { get; set; }
        public int QuestId { get; set; }
        public QuestStatus Status { get; set; }
    }
}
