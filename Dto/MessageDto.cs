using WhatsappBot.Entities;

namespace WhatsappBot.Dto
{
    public class MessageDto
    {
        public string Content { get; set; }
        public string TypeMessage { get; set; }
        public string Caption { get; set; }
        public string SessionName { get; set; }
        public string DestinationNumber { get; set; }
        public string FileName { get; set; }
    }
}