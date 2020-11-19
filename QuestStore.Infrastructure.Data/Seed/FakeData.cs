using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.Infrastructure.Data.Seed
{
    public class FakeData
    {
        private const int FakesNumber = 10;
        public List<Quest> FakeQuests { get; }
        public List<Artifact> FakeArtifacts { get; }
        public List<Student> FakeStudents { get; }
        public List<Classroom> FakeClassrooms { get; }
        public List<Mentor> FakeMentors { get; }
        public List<StudentArtifact> FakeStudentArtifacts { get; }
        public List<StudentQuest> FakeStudentQuests { get; }
        public List<StudentClassroom> FakeStudentClassrooms { get; }
        public List<MentorClassroom> FakeMentorClassrooms { get; }

        public FakeData()
        {
            Randomizer.Seed = new Random(8675309);

            var questId = 1;
            var questFaker = new Faker<Quest>()
                .StrictMode(false)
                .RuleFor(q => q.Id, f => questId++)
                .RuleFor(q => q.Name, f => f.Commerce.ProductName())
                .RuleFor(q => q.Description, f => f.Commerce.ProductDescription())
                .RuleFor(q => q.Reward, f => f.Random.Number(1000))
                .RuleFor(q => q.Type, f => f.PickRandom<QuestType>());
            FakeQuests = questFaker.Generate(FakesNumber);

            var artifactId = 1;
            var artifactFaker = new Faker<Artifact>()
                .StrictMode(false)
                .RuleFor(a => a.Id, f => artifactId++)
                .RuleFor(a => a.Name, f => f.Commerce.ProductName())
                .RuleFor(a => a.Description, f => f.Commerce.ProductDescription())
                .RuleFor(a => a.Cost, f => f.Random.Number(1000))
                .RuleFor(a => a.Quantity, f => f.Random.Number(10).OrNull(f, 0.4f))
                .RuleFor(a => a.Type, f => f.PickRandom<ArtifactType>());
            FakeArtifacts = artifactFaker.Generate(FakesNumber);

            var studentId = 1;
            var studentFaker = new Faker<Student>()
                .StrictMode(false)
                .RuleFor(s => s.Id, f => studentId++)
                .RuleFor(s => s.Name, f => f.Person.FirstName)
                .RuleFor(s => s.Description, f => f.Hacker.Phrase())
                .RuleFor(s => s.Surname, f => f.Person.LastName)
                .RuleFor(s => s.Email, f => f.Person.Email)
                .RuleFor(s => s.Coins, f => f.Random.Number(1000));
            FakeStudents = studentFaker.Generate(FakesNumber);

            var classroomId = 1;
            var classroomFaker = new Faker<Classroom>()
                .StrictMode(false)
                .RuleFor(s => s.Id, f => classroomId++)
                .RuleFor(s => s.Name, f => f.Company.CompanyName())
                .RuleFor(s => s.Description, f => f.Company.CatchPhrase());
            FakeClassrooms = classroomFaker.Generate(FakesNumber/3);

            // Mentor and student entity inherit from user class and thus they are both in the user table
            // so they also have the same column of ids. Therefore mentorId must start where studentId ends.
            var mentorId = studentId;
            var mentorFaker = new Faker<Mentor>()
                .StrictMode(false)
                .RuleFor(s => s.Id, f => mentorId++)
                .RuleFor(s => s.Name, f => f.Person.FirstName)
                .RuleFor(s => s.Description, f => f.Hacker.Phrase())
                .RuleFor(s => s.Surname, f => f.Person.LastName)
                .RuleFor(s => s.Email, f => f.Person.Email);
            FakeMentors = mentorFaker.Generate(FakesNumber/2);

            var studentArtifactId = 2;
            var studentArtifactPairs = GenerateRandomPairs(
                FakeStudents.Select(fs => fs.Id).ToList(),
                FakeArtifacts.Select(fa => fa.Id).ToList(), 2*FakesNumber);
            var studentArtifactFaker = new Faker<StudentArtifact>()
                .StrictMode(false)
                .RuleFor(sa => sa.StudentId, f =>
                    studentArtifactPairs[studentArtifactId - 2].Item1)
                .RuleFor(sa => sa.ArtifactId, f =>
                    studentArtifactPairs[studentArtifactId - 2].Item2)
                .RuleFor(sa => sa.PurchasedQuantity, f => f.Random.Number(10))
                .FinishWith((f, sa) => studentArtifactId++);
            FakeStudentArtifacts = studentArtifactFaker.Generate(2*FakesNumber);

            var studentQuestId = 2;
            var studentQuestPairs = GenerateRandomPairs(
                FakeStudents.Select(fs => fs.Id).ToList(),
                FakeQuests.Select(fq => fq.Id).ToList(), 2*FakesNumber);
            var studentQuestFaker = new Faker<StudentQuest>()
                .StrictMode(false)
                .RuleFor(sq => sq.StudentId, f =>
                    studentQuestPairs[studentQuestId - 2].Item1)
                .RuleFor(sq => sq.QuestId, f =>
                    studentQuestPairs[studentQuestId - 2].Item2)
                .RuleFor(sq => sq.Status, f => f.PickRandom<QuestStatus>())
                .FinishWith((f, sa) => studentQuestId++);
            FakeStudentQuests = studentQuestFaker.Generate(2*FakesNumber);

            var studentClassroomId = 2;
            var studentClassroomPairs = GenerateRandomPairs(
                FakeStudents.Select(fs => fs.Id).ToList(),
                FakeClassrooms.Select(fc => fc.Id).ToList(), 2*FakesNumber);
            var studentClassroomFaker = new Faker<StudentClassroom>()
                .StrictMode(false)
                .RuleFor(sq => sq.StudentId, f =>
                    studentClassroomPairs[studentClassroomId - 2].Item1)
                .RuleFor(sq => sq.ClassroomId, f =>
                    studentClassroomPairs[studentClassroomId - 2].Item2)
                .FinishWith((f, sa) => studentClassroomId++);
            FakeStudentClassrooms = studentClassroomFaker.Generate(2*FakesNumber);

            var mentorClassroomId = 2;
            var mentorClassroomPairs = GenerateRandomPairs(
                FakeMentors.Select(fs => fs.Id).ToList(),
                FakeClassrooms.Select(fc => fc.Id).ToList(), FakesNumber);
            var mentorClassroomFaker = new Faker<MentorClassroom>()
                .StrictMode(false)
                .RuleFor(sq => sq.MentorId, f =>
                    mentorClassroomPairs[mentorClassroomId - 2].Item1)
                .RuleFor(sq => sq.ClassroomId, f =>
                    mentorClassroomPairs[mentorClassroomId - 2].Item2)
                .FinishWith((f, sa) => mentorClassroomId++);
            FakeMentorClassrooms = mentorClassroomFaker.Generate(FakesNumber);
        }

        public static List<(T1, T2)> GenerateRandomPairs<T1, T2>(List<T1> first, List<T2> second, int length)
        {
            if (length > first.Count * second.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length of return list must be smaller or equal to the product of the lengths of the lists used for the drawing");
            }

            var result = new HashSet<(T1, T2)>();
            var randomizer = new Randomizer();
            var i = 0;
            while (i < length)
            {
                var pair = (randomizer.ListItem(first), randomizer.ListItem(second));
                if (result.Add(pair))
                {
                    ++i;
                }
            }

            return result.ToList();
        }
    }
}
