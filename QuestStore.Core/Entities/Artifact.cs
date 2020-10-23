using System;
using System.Collections.Generic;

namespace QuestStore.Core.Entities
{
    public class Artifact : ResourceEntity
    {
        public int Cost { get; set; }
        public int? Quantity { get; set; }
        public ICollection<StudentArtifact> StudentArtifacts { get; set; }

    }
}
