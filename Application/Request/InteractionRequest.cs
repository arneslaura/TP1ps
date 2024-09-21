using System;

namespace Application.Request
{
    public class InteractionRequest
    {
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public int InteractionType { get; set; }
    }
}
