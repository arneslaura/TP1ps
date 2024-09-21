using System;

namespace Domain.Entities
{
    public class CampaignType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Project> Projects { get; set; }
    }
}
