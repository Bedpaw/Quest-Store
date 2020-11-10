using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class Student : User
    {
        public int Coins { get; set; }
        public ICollection<StudentArtifact> StudentArtifacts { get; set; }
        public ICollection<StudentClassroom> StudentClassrooms { get; set; }
        public ICollection<StudentQuest> StudentQuests { get; set; }
    }
}
