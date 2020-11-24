using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IClassroomRepository : ILinkingRepository<StudentClassroom>
    {
        Task<List<Student>> GetClassroomStudentsWithStudentArtifact(int classroomId, int artifactId);
        Task<List<Student>> GetClassroomStudentsWithQuests(int classroomId, Func<StudentQuest, bool> filter);
    }
}
