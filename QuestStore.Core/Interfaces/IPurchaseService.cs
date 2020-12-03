using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IPurchaseService
    {
        Task<StudentArtifact> StudentBuyArtifact(int studentId, int artifactId);
        Task<bool> ClassBuyArtifact(int classroomId, int artifactId);
        Task StudentReturnArtifact(int studentId, int artifactId);
    }
}
