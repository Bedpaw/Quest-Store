using System;
using System.Collections.Generic;
using QuestStore.Core.Entities;

namespace QuestStore.Core.Entities
{
    public class User : ResourceEntity
    {
        public string Role { get; private set; }
        public string AuthId { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
