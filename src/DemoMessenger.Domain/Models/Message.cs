using System;

namespace DemoMessenger.Domain.Models
{
    public class Message
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
