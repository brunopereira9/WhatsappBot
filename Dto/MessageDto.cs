using WhatsappBot.Entities;

namespace WhatsappBot.Dto
{
    public class MessageDto
    {
        public int ContactId { get; set; }
        public string Content { get; set; }
        public TypeMessage TypeMessage { get; set; }
        public string? Caption { get; set; }
        public string? SessionName { get; set; }
        public string DestinationNumber { get; set; }
        public string? FileName { get; set; }
    }

    public enum TypeMessage
    {
        Text = 0,
        File = 1
    }
}