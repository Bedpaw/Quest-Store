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


            //Response Dtos
            CreateMap<Student, StudentBriefDto>();
            CreateMap<Artifact, ArtifactBriefDto>();
            CreateMap<Mentor, MentorBriefDto>();
            CreateMap<Classroom, ClassroomBriefDto>();

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
