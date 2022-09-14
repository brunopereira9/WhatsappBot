using WhatsappBot.Dto;

namespace WhatsappBot.Entities
{
    public class MessageEntity
    {

        public MessageEntity(
            string content, 
            TypeMessage typeMessage, 
            string caption, 
            string sessionName,
            string destinationNumber,
            string fileName)
        {
            Content = content;
            TypeMessage = typeMessage;
            Caption = caption;
            SessionName = sessionName;
            DestinationNumber = destinationNumber;
            FileName = fileName;
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public int ContactId { get; private set; }
        public string Content  { get; private set; }
        public TypeMessage TypeMessage  { get; private set; }
        public string Caption { get; private set; }
        public string SessionName { get; private set; }
        public string DestinationNumber { get; private set; }
        public string FileName { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
    }
}