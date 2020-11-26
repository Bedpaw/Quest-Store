using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuestStore.API.Dtos.InDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.Profiles
{
    public class StoreInProfile : Profile
    {
        public StoreInProfile()
        {
            //Normal entities dtos.
            CreateMap<StudentRequestDto, Student>();
            CreateMap<MentorRequestDto, Mentor>();
            CreateMap<ClassroomRequestDto, Classroom>();

            //Linking table entities dtos.
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
        }
    }
}
