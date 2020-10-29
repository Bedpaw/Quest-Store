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
        public static Dictionary<Type, GenericControllerConfiguration> GenericControllersConfigurations =>
            new Dictionary<Type, GenericControllerConfiguration>
            {
                {
                    typeof(Quest),
                    new GenericControllerConfiguration {ResponseType = typeof(Quest), RequestType = typeof(Quest)}
                },
                {
                    typeof(User),
                    new GenericControllerConfiguration {ResponseType = typeof(User), RequestType = typeof(User)}
                },
                {
                    typeof(Artifact),
                    new GenericControllerConfiguration
                    {
                        ResponseType = typeof(ArtifactDetailedDto),
                        RequestType = typeof(ArtifactDetailedDto)
                    }
                },
                {
                    typeof(Classroom),
                    new GenericControllerConfiguration
                    {
                        ResponseType = typeof(ClassroomDetailedDto),
                        RequestType = typeof(ClassroomRequestDto)
                    }
                },
                {
                    typeof(Student),
                    new GenericControllerConfiguration
                    {
                        ResponseType = typeof(StudentDetailedDto), RequestType = typeof(StudentRequestDto)
                    }
                },
                {
                    typeof(Mentor),
                    new GenericControllerConfiguration
                    {
                        ResponseType = typeof(MentorDetailedDto), RequestType = typeof(MentorRequestDto)
                    }
                }
            };

        public static Dictionary<Type, LinkingControllerConfiguration> LinkingControllersConfigurations =>
            new Dictionary<Type, LinkingControllerConfiguration>
            {
                {
                    typeof(StudentArtifact), 
                    new LinkingControllerConfiguration
                    {
                        ResponseType = typeof(ArtifactDetailedDto),
                        Name = nameof(StudentArtifact) + "s",
                        ParentRoute = nameof(Student) + "s",
                        ChildRoute = nameof(Artifact) + "s"
                        
                    }
                }
            };
    }
}
