using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuestStore.API.Dtos.OutDtos;
using QuestStore.Core.Entities;

namespace QuestStore.API.Profiles
{
    public class QuestWithStudentsListConverter : ITypeConverter<List<StudentQuest>, List<QuestWithStudentsDto>>
    {
        public List<QuestWithStudentsDto> Convert(List<StudentQuest> studentQuests, List<QuestWithStudentsDto> quests, ResolutionContext context)
        {
            quests = new List<QuestWithStudentsDto>();
            foreach (var studentQuest in studentQuests)
            {
                var quest = quests.FirstOrDefault(q => q.Id == studentQuest.QuestId);
                if (quest != null)
                {
                    quest.Students.Add(context.Mapper.Map<StudentBriefDto>(studentQuest.Student));
                }
                else
                {
                    quests.Add(
                        new QuestWithStudentsDto
                        {
                            Id = studentQuest.QuestId,
                            Name = studentQuest.Quest.Name,
                            Students = new List<StudentBriefDto>
                            {
                                context.Mapper.Map<StudentBriefDto>(studentQuest.Student)
                            }
                        });
                }
            }

            return quests;
        }
    }
}
