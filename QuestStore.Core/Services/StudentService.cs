using System;
using System.Collections.Generic;
using System.Linq;
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
            _unitOfWork.NoTracking = false;
        }
        public async Task<bool> BuyArtifact(int studentId, int artifactId)
        {
            var student = await _unitOfWork.GenericRepository<Student>().GetById(studentId);
            if (student == null) throw new ArgumentException("There is no student with the given id.");

            var artifact = await _unitOfWork.GenericRepository<Artifact>().GetById(artifactId);
            if (artifact == null) throw new ArgumentException("There is no artifact with the given id.");

            if (student.Coins < artifact.Cost || artifact.Quantity <= 0)
            {
                return false;
            }

            student.Coins -= artifact.Cost;
            artifact.Quantity -= 1;
            student.StudentArtifacts ??= new List<StudentArtifact>();
            student.StudentArtifacts.Add(new StudentArtifact {ArtifactId = artifactId});
            await _unitOfWork.Save();
            return true;

        }

        public async Task<bool> ClassBuyArtifact(int classroomId, int artifactId)
        {
            var artifact = await _unitOfWork.GenericRepository<Artifact>().GetById(artifactId);
            if (artifact == null) throw new ArgumentException("There is no artifact with the given id.");

            //TODO: Add type of artifact(basic, extra)
            if (artifact.Quantity <= 0)
            {
                return false;
            }

            var students = (await _unitOfWork.LinkingRepository<StudentClassroom>()
                .GetBySingleId(classroomId, false, 1))?.Select(sc => sc.Student).ToList();
            if (students == null)
                throw new ArgumentException(
                    "There are no students within the given classroom or the wrong classroom id.");

            var costPerStudent = artifact.Cost / students.Count;

            foreach (var student in students)
            {
                if (student.Coins >= costPerStudent)
                {
                    student.Coins -= costPerStudent;
                    student.StudentArtifacts ??= new List<StudentArtifact>();
                    student.StudentArtifacts.Add(new StudentArtifact {ArtifactId = artifactId});
                }
                else
                {
                    return false;
                }
            }

            await _unitOfWork.Save();
            return true;
        }
    }
}
