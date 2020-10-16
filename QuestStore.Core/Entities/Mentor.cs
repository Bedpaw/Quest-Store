using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class Mentor : User
    {
        public ICollection<MentorClassroom> Classrooms { get; set; }
    }
}
