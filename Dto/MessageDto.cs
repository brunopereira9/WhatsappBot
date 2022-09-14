using WhatsappBot.Entities;
using WhatsappBot.Util.Enum;

namespace WhatsappBot.Dto
{
    public class MessageDto
    {
        public Contact Contact { get; set; }
        public string Content { get; set; }
        public TypeMessage TypeMessage { get; set; } = TypeMessage.Text;
        public string? Caption { get; set; }
        public string SessionName { get; set; }
        public string? FileName { get; set; }
    }
}