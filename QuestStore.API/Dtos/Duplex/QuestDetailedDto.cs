using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.API.Dtos.Duplex
{
    public class QuestDetailedDto : ResourceDto
    {
        public int Reward { get; set; }
        public QuestType Type { get; set; }
    }
}
