using System;
using System.Collections.Generic;
using QuestStore.Core.Enums;

namespace QuestStore.Core.Entities
{
    public class Artifact : ResourceEntity
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public ArtifactType Type { get; set; }
        //public ICollection<StudentArtifact> StudentArtifacts { get; set; }

    }
}
