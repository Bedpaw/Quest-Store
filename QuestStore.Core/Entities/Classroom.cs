using System;
using System.Collections.Generic;

namespace QuestStore.Core.Entities
{
    public class Classroom : ResourceEntity
    {
        public ICollection<StudentClassroom> StudentClassrooms { get; set; }
        public ICollection<MentorClassroom> MentorClassrooms { get; set; }
    }
}
