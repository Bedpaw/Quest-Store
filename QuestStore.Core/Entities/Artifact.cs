using System;
using System.Collections.Generic;

namespace QuestStore.Core.Entities
{
    [GenerateController]
    public class Artifact : ResourceEntity
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public ICollection<StudentArtifact> Students { get; set; }

    }
}
