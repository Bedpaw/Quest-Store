using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;
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
                .Select(
                    sc => new Student
                    {
                        //Required
                        Id = sc.StudentId,
                        Coins = sc.Student.Coins,
                        StudentArtifacts = sc.Student.StudentArtifacts
                            .Where(sa => sa.ArtifactId == artifactId)
                            .ToList()
                    })
                .ToListAsync();
        }

        public async Task<List<StudentQuest>> GetClassroomStudentsWithQuests(int classroomId, QuestStatus status)
        {
            var studentsIds = await Entities.Where(sc => sc.ClassroomId == classroomId)
                .Select(sc => sc.StudentId)
                .ToListAsync();

            return await Context.Set<StudentQuest>()
                .Where(sq => studentsIds.Contains(sq.StudentId) && sq.Status == status)
                .Include(sq => sq.Student)
                .Include(sq => sq.Quest)
                .ToListAsync();
        }
    }
}
