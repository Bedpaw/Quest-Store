using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.API.Dtos.Duplex;

namespace QuestStore.API.Dtos.OutDtos
{
    public class StudentMediumDto : ResourceDto
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Coins { get; set; }
    }
}
