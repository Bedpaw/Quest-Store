using System;
using System.Collections.Generic;

namespace QuestStore.Core.Entities
{
    public class Classroom : ResourceEntity
    {
        public ICollection<StudentClassroom> Students { get; set; }
        public ICollection<MentorClassroom> Mentors { get; set; }
    }
}
