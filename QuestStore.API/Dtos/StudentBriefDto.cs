using System.Collections.Generic;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos
{
    public class StudentBriefDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
