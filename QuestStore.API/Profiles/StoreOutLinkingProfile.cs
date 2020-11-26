using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.API.Profiles
{
    public class StoreOutLinkingProfile : Profile
    {
        public StoreOutLinkingProfile()
        {
            //Linking tables post method dtos.
            CreateMap<StudentArtifact, StudentArtifactBriefDto>();
            CreateMap<StudentClassroom, StudentClassroomBriefDto>();
            CreateMap<StudentQuest, StudentQuestBriefDto>();
            CreateMap<MentorClassroom, MentorClassroomBriefDto>();

            //linking tables get method dtos
            CreateMap<Artifact, PurchasedArtifactDetailedDto>();
            CreateMap<StudentArtifact, PurchasedArtifactDetailedDto>()
                .IncludeMembers(sa => sa.Artifact);

            CreateMap<Student, StudentMediumDto>();
            CreateMap<StudentClassroom, StudentMediumDto>()
                .IncludeMembers(sc => sc.Student);

            CreateMap<Mentor, MentorMediumDto>();
            CreateMap<MentorClassroom, MentorMediumDto>()
                .IncludeMembers(mc => mc.Mentor);

            CreateMap<StudentQuest, QuestDetailedDto>()
                .IncludeMembers(sq => sq.Quest);

            //CreateMap<StudentClassroom, ClassroomDetailedDto>()
            //    .IncludeMembers(sc => sc.Classroom);

            //CreateMap<MentorClassroom, ClassroomDetailedDto>()
            //    .IncludeMembers(mc => mc.Classroom);
        }
    }
}
