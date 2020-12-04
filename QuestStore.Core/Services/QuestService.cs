using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.Core.Services
{
    public class QuestService : IQuestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.NoTracking = false;
        }

        public async Task<StudentQuest> FinishQuest(int studentId, int questId)
        {
            var studentQuest = await _unitOfWork.LinkingRepository<StudentQuest>()
                .GetByFullKey(studentId, questId, 1);
            if (studentQuest != null)
            {
                if (studentQuest.Status != QuestStatus.Pending)
                    throw new ArgumentException("The quest have already been completed.");

                studentQuest.Status = QuestStatus.Completed;
            }
            else
            {
                studentQuest = new StudentQuest
                {
                    StudentId = studentId,
                    QuestId = questId,
                    Status = QuestStatus.Completed,
                    Student = await _unitOfWork.GenericRepository<Student>().GetById(studentId),
                    Quest = await _unitOfWork.GenericRepository<Quest>().GetById(questId)
                };
                if (studentQuest.Student == null) throw new ArgumentException("There is no student with the given id.");
                if (studentQuest.Quest == null) throw new ArgumentException("There is no quest with the given id.");

                _unitOfWork.LinkingRepository<StudentQuest>().Add(studentQuest);
            }

            studentQuest.Student.Coins += studentQuest.Quest.Reward;
            await _unitOfWork.Save();
            return studentQuest;
        }

        public async Task UndoFinishQuest(int studentId, int questId)
        {
            var studentQuest = await _unitOfWork.LinkingRepository<StudentQuest>()
                .GetByFullKey(studentId, questId, 1);
            if (studentQuest == null)
                throw new ArgumentException("The student does not have the quest with given id.");
            if (studentQuest.Status == QuestStatus.Pending) throw new ArgumentException("The quest is not finished");

            studentQuest.Status = QuestStatus.Pending;
            studentQuest.Student.Coins -= studentQuest.Quest.Reward;
            if (studentQuest.Student.Coins < 0) studentQuest.Student.Coins = 0;

            await _unitOfWork.Save();
        }
    }
}
