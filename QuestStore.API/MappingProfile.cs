using System.Linq;
using AutoMapper;
using QuestStore.API.Dtos;
using QuestStore.Core.Entities;

namespace QuestStore.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentBriefDto>();
            CreateMap<Artifact, ArtifactBriefDto>();
            CreateMap<Mentor, MentorBriefDto>();
            CreateMap<Classroom, ClassroomBriefDto>();

            CreateMap<Artifact, ArtifactDetailedDto>()
                .ForMember(
                    dto => dto.Students,
                    opt =>
                        opt.MapFrom(a => 
                            a.StudentArtifacts.Select(sa => sa.Student).ToList()));

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
