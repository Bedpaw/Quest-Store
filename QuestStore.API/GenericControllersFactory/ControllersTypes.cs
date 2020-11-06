using System;
using System.Collections.Generic;
using QuestStore.API.Dtos;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.GenericControllersFactory
{
    public static class ControllersTypes
    {
        public static Dictionary<(Type entityType, Type responseType, Type requestType), GenericControllerConfiguration> GenericControllers =>
            new Dictionary<(Type entityType, Type responseType, Type requestType), GenericControllerConfiguration>
            {
                {
                    (typeof(Quest), typeof(Quest), typeof(Quest)),
                    new GenericControllerConfiguration()
                },
                {
                    (typeof(User), typeof(User), typeof(User)),
                    new GenericControllerConfiguration()
                },
                {
                    (typeof(Artifact), typeof(ArtifactDetailedDto), typeof(ArtifactDetailedDto)),
                    new GenericControllerConfiguration()
                },
                {
                    (typeof(Classroom), typeof(ClassroomDetailedDto), typeof(ClassroomRequestDto)),
                    new GenericControllerConfiguration()
                },
                {
                    (typeof(Student), typeof(StudentDetailedDto), typeof(StudentRequestDto)),
                    new GenericControllerConfiguration()
                },
                {
                    (typeof(Mentor), typeof(MentorDetailedDto), typeof(MentorRequestDto)),
                    new GenericControllerConfiguration()
                }
            };

        public static Dictionary<(Type entityType, Type responseType, Type postResponseType), LinkingControllerConfiguration> LinkingControllers =>
            new Dictionary<(Type entityType, Type responseType, Type postResponseType), LinkingControllerConfiguration>
            {
                {
                    (typeof(StudentArtifact), typeof(ArtifactDetailedDto), typeof(StudentArtifactBrief)),
                    new LinkingControllerConfiguration
                    {
                        Name = nameof(Student) + "s",
                        ParentRoute = nameof(Student) + "s",
                        ChildRoute = nameof(Artifact) + "s",
                        ReverseKeyOrder = false
                    }
                },
                {
                    (typeof(StudentClassroom), typeof(ClassroomDetailedDto), typeof(StudentClassroomBrief)),
                    new LinkingControllerConfiguration
                    {
                        Name = nameof(Student) + "s",
                        ParentRoute = nameof(Student) + "s",
                        ChildRoute = nameof(Classroom) + "s",
                        ReverseKeyOrder = false
                    }
                },
                {
                    (typeof(StudentClassroom), typeof(StudentDetailedDto), typeof(StudentClassroomBrief)),
                    new LinkingControllerConfiguration
                    {
                        Name = nameof(Classroom) + "s",
                        ParentRoute = nameof(Classroom) + "s",
                        ChildRoute = nameof(Student) + "s",
                        ReverseKeyOrder = true
                    }
                },
                {
                    (typeof(MentorClassroom), typeof(ClassroomDetailedDto), typeof(MentorClassroomBrief)),
                    new LinkingControllerConfiguration
                    {
                        Name = nameof(Mentor) + "s",
                        ParentRoute = nameof(Mentor) + "s",
                        ChildRoute = nameof(Classroom) + "s",
                        ReverseKeyOrder = false
                    }
                },
                {
                    (typeof(MentorClassroom), typeof(MentorDetailedDto), typeof(MentorClassroomBrief)),
                    new LinkingControllerConfiguration
                    {
                        Name = nameof(Classroom) + "s",
                        ParentRoute = nameof(Classroom) + "s",
                        ChildRoute = nameof(Mentor) + "s",
                        ReverseKeyOrder = true
                    }
                }
            };
    }
}
