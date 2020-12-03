using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Interfaces
{
    public interface IQuestService
    {
        Task<StudentQuest> FinishQuest(int studentId, int questId);
        Task UndoFinishQuest(int studentId, int questId);

    }
}
