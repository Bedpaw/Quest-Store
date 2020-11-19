using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.API.Dtos.Duplex;

namespace QuestStore.API.Dtos.OutDtos
{
    public class PurchasedArtifactDetailedDto : ArtifactDetailedDto
    {
        public int PurchasedQuantity { get; set; }
    }
}
