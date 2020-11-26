using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.GenericControllersFactory
{
    public static class ControllersTypes
    {
        public static
            ReadOnlyDictionary<(Type entityType, Type responseType, Type requestType),
                GenericControllerConfiguration> GenericControllers
        {
            get;
        } =
            new ReadOnlyDictionary<(Type entityType, Type responseType, Type requestType),
                GenericControllerConfiguration>(
                new Dictionary<(Type entityType, Type responseType, Type requestType),
                    GenericControllerConfiguration>
                {
                    {
                        (typeof(Quest), typeof(QuestDetailedDto), typeof(QuestDetailedDto)),
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
                });

        public static
            ReadOnlyDictionary<(Type entityType, Type responseType, Type postResponseType),
                LinkingControllerConfiguration> LinkingControllers
        {
            get;
        } =
            new ReadOnlyDictionary<(Type entityType, Type responseType, Type postResponseType),
                LinkingControllerConfiguration>(
                new Dictionary<(Type entityType, Type responseType, Type postResponseType),
                    LinkingControllerConfiguration>
                {
                    {
                        (typeof(StudentArtifact), typeof(PurchasedArtifactDetailedDto), typeof(StudentArtifactBriefDto)),
                        new LinkingControllerConfiguration
                        {
                            Name = nameof(Student) + "s",
                            ParentRoute = nameof(Student) + "s",
                            ChildRoute = nameof(Artifact) + "s",
                            ReverseKeyOrder = false
                        }
                    },
                    {
                        (typeof(StudentQuest), typeof(QuestDetailedDto), typeof(StudentQuestBriefDto)),
                        new LinkingControllerConfiguration
                        {
                            Name = nameof(Student) + "s",
                            ParentRoute = nameof(Student) + "s",
                            ChildRoute = nameof(Quest) + "s",
                            ReverseKeyOrder = false
                        }
                    },
                    {
                        (typeof(StudentClassroom), typeof(StudentMediumDto), typeof(StudentClassroomBriefDto)),
                        new LinkingControllerConfiguration
                        {
                            Name = nameof(Classroom) + "s",
                            ParentRoute = nameof(Classroom) + "s",
                            ChildRoute = nameof(Student) + "s",
                            ReverseKeyOrder = true
                        }
                    },
                    {
                        (typeof(MentorClassroom), typeof(MentorMediumDto), typeof(MentorClassroomBriefDto)),
                        new LinkingControllerConfiguration
                        {
                            Name = nameof(Classroom) + "s",
                            ParentRoute = nameof(Classroom) + "s",
                            ChildRoute = nameof(Mentor) + "s",
                            ReverseKeyOrder = true
                        }
                    }
                    //{
                    //    (typeof(StudentClassroom), typeof(ClassroomDetailedDto),
                    //        typeof(StudentClassroomBriefDto)),
                    //    new LinkingControllerConfiguration
                    //    {
                    //        Name = nameof(Student) + "s",
                    //        ParentRoute = nameof(Student) + "s",
                    //        ChildRoute = nameof(Classroom) + "s",
                    //        ReverseKeyOrder = false
                    //    }
                    //},
                    //{
                    //    (typeof(MentorClassroom), typeof(ClassroomDetailedDto), typeof(MentorClassroomBriefDto)),
                    //    new LinkingControllerConfiguration
                    //    {
                    //        Name = nameof(Mentor) + "s",
                    //        ParentRoute = nameof(Mentor) + "s",
                    //        ChildRoute = nameof(Classroom) + "s",
                    //        ReverseKeyOrder = false
                    //    }
                    //}
                });
    }
}
