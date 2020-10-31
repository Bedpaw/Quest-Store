using System.Linq;
using AutoMapper;
using QuestStore.API.Dtos;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API
{
    public class QuestStoreProfile : Profile
    {
        public QuestStoreProfile()
        {
            //DuplexDtos
            CreateMap<Artifact, ArtifactDetailedDto>().ReverseMap();
            //.ForMember(
            //    dto => dto.Students,
            //    opt =>
            //        opt.MapFrom(a => 
            //            a.StudentArtifacts.Select(sa => sa.Student).ToList()));

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
            CreateMap<Artifact, ArtifactBriefDto>();
            CreateMap<Mentor, MentorBriefDto>();
            CreateMap<Classroom, ClassroomBriefDto>();
            CreateMap<StudentArtifact, StudentArtifactBrief>();
            CreateMap<StudentClassroom, StudentClassroomBrief>();
            CreateMap<MentorClassroom, MentorClassroomBrief>();

            CreateMap<StudentArtifact, ArtifactDetailedDto>()
                .IncludeMembers(sa => sa.Artifact);

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
                            s.StudentArtifacts.Select(sa => sa.Artifact).ToList()))
                .ForMember(dto => dto.Classrooms,
                    opt =>
                        opt.MapFrom(s => 
                            s.StudentClassrooms.Select(sc => sc.Classroom).ToList()));

            CreateMap<Classroom, ClassroomDetailedDto>()
                .ForMember(dto => dto.Students,
                    opt =>
                        opt.MapFrom(c =>
                            c.StudentClassrooms.Select(sc => sc.Student).ToList()))
                .ForMember(dto => dto.Students,
                    opt =>
                        opt.MapFrom(c =>
                            c.MentorClassrooms.Select(mc => mc.Mentor).ToList()));

        }
    }
}
