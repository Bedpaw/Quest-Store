using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class MentorClassroom
    {
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
}
}
