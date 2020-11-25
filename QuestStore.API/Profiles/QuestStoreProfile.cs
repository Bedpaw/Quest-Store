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
    public class QuestStoreProfile : Profile
    {
        public QuestStoreProfile()
        {
            //DuplexDtos
            CreateMap<Artifact, ArtifactDetailedDto>().ReverseMap();
            CreateMap<Quest, QuestDetailedDto>().ReverseMap();

            //RequestDtos
            CreateMap<StudentRequestDto, Student>();
            CreateMap<MentorRequestDto, Mentor>();
            CreateMap<ClassroomRequestDto, Classroom>();

            CreateMap<LinkingDto, StudentArtifact>()
                .ForMember(
                    sa => sa.StudentId,
                    opt =>
                        opt.MapFrom(ld => ld.Id1))
                .ForMember(
                    sa => sa.ArtifactId,
                    opt =>
                        opt.MapFrom(ld => ld.Id2));

            CreateMap<LinkingDto, StudentClassroom>()
                .ForMember(
                    sc => sc.StudentId,
                    opt =>
                        opt.MapFrom(ld => ld.Id1))
                .ForMember(
                    sc => sc.ClassroomId,
                    opt =>
                        opt.MapFrom(ld => ld.Id2));

            CreateMap<LinkingDto, StudentQuest>()
                .ForMember(
                    sq => sq.StudentId,
                    opt =>
                        opt.MapFrom(ld => ld.Id1))
                .ForMember(
                    sq => sq.QuestId,
                    opt =>
                        opt.MapFrom(ld => ld.Id2));

            CreateMap<LinkingDto, MentorClassroom>()
                .ForMember(
                    mc => mc.MentorId,
                    opt =>
                        opt.MapFrom(ld => ld.Id1))
                .ForMember(
                    mc => mc.ClassroomId,
                    opt =>
                        opt.MapFrom(ld => ld.Id2));

            //Response Dtos
            CreateMap<Student, StudentBriefDto>();
            CreateMap<Mentor, MentorBriefDto>();
            CreateMap<Classroom, ClassroomBriefDto>();
            CreateMap<Quest, QuestBriefDto>();
            CreateMap<Artifact, PurchasedArtifactBriefDto>();
            CreateMap<StudentArtifact, PurchasedArtifactBriefDto>()
                .IncludeMembers(sa => sa.Artifact);

            CreateMap<StudentArtifact, StudentArtifactBriefDto>();
            CreateMap<StudentClassroom, StudentClassroomBriefDto>();
            CreateMap<StudentQuest, StudentQuestBriefDto>();
            CreateMap<MentorClassroom, MentorClassroomBriefDto>();

            CreateMap<Artifact, PurchasedArtifactDetailedDto>();
            CreateMap<StudentArtifact, PurchasedArtifactDetailedDto>()
                .IncludeMembers(sa => sa.Artifact);
            CreateMap<StudentQuest, QuestDetailedDto>()
                .IncludeMembers(sq => sq.Quest);
            CreateMap<StudentClassroom, ClassroomDetailedDto>()
                .IncludeMembers(sc => sc.Classroom);
            CreateMap<StudentClassroom, StudentDetailedDto>()
                .IncludeMembers(sc => sc.Student);
            CreateMap<MentorClassroom, ClassroomDetailedDto>()
                .IncludeMembers(mc => mc.Classroom);
            CreateMap<MentorClassroom, MentorDetailedDto>()
                .IncludeMembers(mc => mc.Mentor);

            CreateMap<List<StudentQuest>, List<QuestWithStudentsDto>>().ConvertUsing<QuestWithStudentsListConverter>();

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
