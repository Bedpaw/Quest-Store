using System;
using System.Collections.Generic;
using QuestStore.API.Dtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.GenericControllersFactory
{
    public static class ControllersTypes
    {
        public static Dictionary<Type, ControllerConfiguration> Configurations =>
            new Dictionary<Type, ControllerConfiguration>
            {
                {typeof(Quest), new ControllerConfiguration {ResponseType = typeof(Quest)}},
                {typeof(Artifact), new ControllerConfiguration {ResponseType = typeof(ArtifactDetailedDto)}},
                {typeof(Classroom), new ControllerConfiguration {ResponseType = typeof(ClassroomDetailedDto)}},
                {typeof(Student), new ControllerConfiguration {ResponseType = typeof(StudentDetailedDto)}},
                {typeof(Mentor), new ControllerConfiguration {ResponseType = typeof(MentorDetailedDto)}},
                {typeof(User), new ControllerConfiguration {ResponseType = typeof(User)}}
            };
    }
}
