using System;
using System.Collections.Generic;
using System.Text;

namespace QuestStore.Core.Entities
{
    public class StudentArtifact 
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ArtifactId { get; set; }
        public Artifact Artifact { get; set; }
        public int PurchasedQuantity { get; set; }
    }
}
