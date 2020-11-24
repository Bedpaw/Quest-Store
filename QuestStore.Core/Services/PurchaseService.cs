using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
using QuestStore.Core.Interfaces;

namespace QuestStore.Core.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.NoTracking = false;
        }
        public async Task<StudentArtifact> StudentBuyArtifact(int studentId, int artifactId)
        {
            var student = await _unitOfWork.GenericRepository<Student>().GetById(studentId);
            if (student == null) throw new ArgumentException("There is no student with the given id.");

            var artifact = await _unitOfWork.GenericRepository<Artifact>().GetById(artifactId);
            if (artifact == null) throw new ArgumentException("There is no artifact with the given id.");

            if (student.Coins < artifact.Cost || artifact.Type == ArtifactType.Extra ||
                artifact.Quantity <= 0 && artifact.Quantity != null) return null;

            student.Coins -= artifact.Cost;
            artifact.Quantity--;

            var studentArtifact = await _unitOfWork.LinkingRepository<StudentArtifact>()
                .GetByFullKey(studentId, artifactId);
            if (studentArtifact != null)
            {
                studentArtifact.PurchasedQuantity++;
            }
            else
            {
                studentArtifact = new StudentArtifact {StudentId = studentId, ArtifactId = artifactId, PurchasedQuantity = 1};
                student.StudentArtifacts ??= new List<StudentArtifact> {studentArtifact};
            }

            await _unitOfWork.Save();
            return studentArtifact;
        }

        public async Task<bool> ClassBuyArtifact(int classroomId, int artifactId)
        {
            var artifact = await _unitOfWork.GenericRepository<Artifact>().GetById(artifactId);
            if (artifact == null) throw new ArgumentException("There is no artifact with the given id.");

            if (artifact.Quantity <= 0 || artifact.Type == ArtifactType.Basic) return false;

            var students =
                await _unitOfWork.ClassroomRepository.GetClassroomStudentsWithStudentArtifact(classroomId, artifactId);
            if (students == null || students.Count == 0)
                throw new ArgumentException(
                    "There are no students within the given classroom or the wrong classroom id.");

            var costPerStudent = artifact.Cost / students.Count;

            foreach (var student in students)
            {
                if (student.Coins >= costPerStudent)
                {
                    student.Coins -= costPerStudent;
                    
                    if (student.StudentArtifacts != null && student.StudentArtifacts.Count > 0)
                    {
                        student.StudentArtifacts.Single().PurchasedQuantity++;
                    }
                    else
                    {
                        var studentArtifact = new StudentArtifact
                            {StudentId = student.Id, ArtifactId = artifactId, PurchasedQuantity = 1};
                        student.StudentArtifacts ??= new List<StudentArtifact> {studentArtifact};
                        //We must add the entry manually because EFCore doesn't do it automatically for no reason.
                        _unitOfWork.LinkingRepository<StudentArtifact>().Add(studentArtifact);
                    }
                }
                else
                {
                    return false;
                }
            }

            artifact.Quantity--;
            await _unitOfWork.Save();
            return true;
        }
    }
}
