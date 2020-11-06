using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuestStore.Core.Interfaces
{
    public interface IStudentService
    {
        Task<bool> BuyArtifact(int studentId, int artifactId);
    }
}
