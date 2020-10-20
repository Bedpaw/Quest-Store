using System;
using System.Collections.Generic;
using System.Text;
using QuestStore.Core.Enums;

namespace QuestStore.Core.Entities
{
    public class Quest : ResourceEntity
    {
        public int Reward { get; set; }
        public QuestType Type { get; set; }
    }
}
