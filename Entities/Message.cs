using WhatsappBot.Util.Enum;

namespace WhatsappBot.Entities
{
    public class Message
    {

        public Message(
            Contact contact,
            string content, 
            string sessionName, 
            string fileName = null,
            string caption = null, 
            TypeMessage typeMessage = TypeMessage.Text)
        {
            Content = content;
            TypeMessage = typeMessage;
            Caption = caption;
            SessionName = sessionName;
            Contact = contact;
            FileName = fileName;
        }

        public int Id { get; private set; }
        public Contact Contact { get; private set; }
        public string Content  { get; private set; }
        public TypeMessage TypeMessage  { get; private set; } = TypeMessage.Text;
        public string SessionName { get; private set; }
        public string? Caption { get; private set; }
        public string? FileName { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

    }
    
}