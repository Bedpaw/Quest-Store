using System;
using System.Collections.Generic;
using System.Text;
using QuestStore.Core.Enums;

namespace QuestStore.Core.Entities
{
    public class StudentQuest
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public QuestStatus Status { get; set; }

    }
}
