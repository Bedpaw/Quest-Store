using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;

namespace QuestStore.API.Dtos.Duplex
{
    public class ResourceDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
