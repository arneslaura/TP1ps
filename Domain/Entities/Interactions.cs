using System;

namespace Domain.Entities
{
    public class Interactions
    {
        public Guid InteractionID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Project Project { get; set; }
        public Guid ProjectID { get; set; }

        public InteractionTypes Interactiontype { get; set; }
        public int InteractionType { get; set; }
    }
}
