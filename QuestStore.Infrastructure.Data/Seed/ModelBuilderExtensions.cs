using Microsoft.EntityFrameworkCore;
using QuestStore.Core.Entities;

namespace QuestStore.Infrastructure.Data.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var fakeData = new FakeData();

            modelBuilder.Entity<Quest>().HasData(fakeData.FakeQuests);
            modelBuilder.Entity<Artifact>().HasData(fakeData.FakeArtifacts);
            modelBuilder.Entity<Student>().HasData(fakeData.FakeStudents);
            modelBuilder.Entity<StudentArtifact>().HasData(fakeData.FakeStudentArtifacts);

            //modelBuilder.Entity<Quest>()
            //    .HasData(
            //        new Quest
            //        {
            //            Id = 1, Name = "Finishing two-week assignment", Reward = 100, Type = QuestType.Basic
            //        },
            //        new Quest
            //        {
            //            Id = 2,
            //            Name = "Passing a Checkpoint",
            //            Reward = 500,
            //            Type = QuestType.Basic
            //        });
            //modelBuilder.Entity<Artifact>()
            //    .HasData(
            //        new Artifact {Id = 1, Name = "Private mentoring", Cost = 50},
            //        new Artifact {Id = 2, Name = "You can spend a day in home office", Cost = 300});

        }
    }
}
