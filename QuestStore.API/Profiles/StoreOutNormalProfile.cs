using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;
using QuestStore.Core.Enums;

namespace QuestStore.API.Profiles
{
    public class StoreOutNormalProfile : Profile
    {
        public StoreOutNormalProfile()
        {
            //Normal entities dtos
            CreateMap<Student, StudentBriefDto>();
            CreateMap<Mentor, MentorBriefDto>();
            CreateMap<Classroom, ClassroomBriefDto>();
            CreateMap<Quest, QuestBriefDto>();
            CreateMap<Artifact, PurchasedArtifactBriefDto>();
            CreateMap<StudentArtifact, PurchasedArtifactBriefDto>()
                .IncludeMembers(sa => sa.Artifact);

            //The below mappings use the definitions from above.
            CreateMap<Mentor, MentorDetailedDto>()
                .ForMember(
                    dto => dto.Classrooms,
                    opt =>
                        opt.MapFrom(m =>
                            m.MentorClassrooms.Select(mc => mc.Classroom).ToList()));

            CreateMap<Student, StudentDetailedDto>()
                .ForMember(dto => dto.Artifacts,
                    opt =>
                        opt.MapFrom(s =>
                            s.StudentArtifacts))
                .ForMember(dto => dto.Classrooms,
                    opt =>
                        opt.MapFrom(s =>
                            s.StudentClassrooms.Select(sc => sc.Classroom).ToList()))
                .ForMember(dto => dto.PendingQuests,
                    opt =>
                        opt.MapFrom(s =>
                            s.StudentQuests.Where(sq => sq.Status == QuestStatus.Pending)
                                .Select(sq => sq.Quest).ToList()))
                .ForMember(dto => dto.CompletedQuests,
                opt =>
                    opt.MapFrom(s =>
                        s.StudentQuests.Where(sq => sq.Status == QuestStatus.Completed)
                            .Select(sq => sq.Quest).ToList()));

            CreateMap<Classroom, ClassroomDetailedDto>()
                .ForMember(dto => dto.Students,
                    opt =>
                        opt.MapFrom(c =>
                            c.StudentClassrooms.Select(sc => sc.Student).ToList()))
                .ForMember(dto => dto.Mentors,
                    opt =>
                        opt.MapFrom(c =>
                            c.MentorClassrooms.Select(mc => mc.Mentor).ToList()));
        }
    }
}
