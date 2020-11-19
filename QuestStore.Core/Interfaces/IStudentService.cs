using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentArtifact> BuyArtifact(int studentId, int artifactId);
        Task<bool> ClassBuyArtifact(int classroomId, int artifactId);
    }
}
