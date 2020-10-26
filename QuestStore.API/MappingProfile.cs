using System.Linq;
using AutoMapper;
using QuestStore.API.Dtos;
using QuestStore.API.Dtos.InDtos;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //RequestDtos
            CreateMap<ArtifactRequestDto, Artifact>();

            CreateMap<StudentRequestDto, Student>()
                .ForMember(s => s.StudentArtifacts.Select(sa => sa.StudentId),
                    opt => 
                        opt.MapFrom(sr => sr.Id))
                .ForMember(s => s.StudentArtifacts.Select(sa => sa.ArtifactId),
                    opt => 
                        opt.MapFrom(sr => sr.ArtifactsIds.Select(a => a)));


            //Response Dtos
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
