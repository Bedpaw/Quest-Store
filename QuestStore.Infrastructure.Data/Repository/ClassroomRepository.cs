using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.Infrastructure.Data.Repository
{
    public class ClassroomRepository : LinkingRepository<StudentClassroom>, IClassroomRepository
    {
        public ClassroomRepository(StoreDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> GetClassroomStudentsWithStudentArtifact(int classroomId, int artifactId)
        {
            return await Entities.Where(sc => sc.ClassroomId == classroomId)
                .Select(sc => new Student
                {
                    //Required
                    Id = sc.StudentId,
                    Coins = sc.Student.Coins,
                    StudentArtifacts = sc.Student.StudentArtifacts
                        .Where(sa => sa.ArtifactId == artifactId).ToList()
                })
                .ToListAsync();
        }

        public Task<List<Student>> GetClassroomStudentsWithQuests(int classroomId, Func<StudentQuest, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
