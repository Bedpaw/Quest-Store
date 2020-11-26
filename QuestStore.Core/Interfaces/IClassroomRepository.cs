using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.Core.Interfaces
{
    public interface IClassroomRepository : ILinkingRepository<StudentClassroom>
    {
        Task<List<Student>> GetClassroomStudentsWithStudentArtifact(int classroomId, int artifactId);
        Task<List<StudentQuest>> GetClassroomStudentsWithQuests(int classroomId, QuestStatus status);
    }
}
