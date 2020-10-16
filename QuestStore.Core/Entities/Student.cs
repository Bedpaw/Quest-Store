using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class Student : User
    {
        public int Coins { get; set; }
        public ICollection<StudentArtifact> Artifacts { get; set; }
        public ICollection<StudentClassroom> Classrooms { get; set; }
    }
}
