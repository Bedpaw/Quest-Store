using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuestStore.API.Dtos.Duplex;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.Profiles
{
    public class StoreDuplexAndCustomProfile : Profile
    {
        public StoreDuplexAndCustomProfile()
        {
            //Duplex (in and out)
            CreateMap<Artifact, ArtifactDetailedDto>().ReverseMap();
            CreateMap<Quest, QuestDetailedDto>().ReverseMap();

            //Custom mappings
            CreateMap<List<StudentQuest>, List<QuestWithStudentsDto>>().ConvertUsing<QuestWithStudentsListConverter>();
        }
    }
}
