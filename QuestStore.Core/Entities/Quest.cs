using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class Quest : ResourceEntity
    {
        public int Reward { get; set; }
        public QuestType Type { get; set; }
    }
}
