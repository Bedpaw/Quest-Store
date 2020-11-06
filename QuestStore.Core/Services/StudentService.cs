using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> BuyArtifact(int studentId, int artifactId)
        {
            _unitOfWork.TrackingBehavior = TrackingBehavior.TrackAll;
            var student = await _unitOfWork.GenericRepository<Student>().GetById(studentId);
            var artifact = await _unitOfWork.GenericRepository<Artifact>().GetById(artifactId);
            if (student.Coins >= artifact.Cost)
            {
                student.Coins -= artifact.Cost;
                await _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
