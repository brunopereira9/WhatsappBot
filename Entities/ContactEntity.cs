using WhatsappBot.Dto;

namespace WhatsappBot.Entities
{
    public class ContactEntity
    {
        public ContactEntity(string name, string phone, bool isPrivate=false)
        {
            Name = name;
            Phone = phone;
            IsDeleted = false;
            IsPrivate = isPrivate;
            Message = new List<MessageEntity>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public DateTime LastMessageDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsPrivate { get; private set; }
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public List<MessageEntity> Message { get; private set; }
        public void SetMessageStock(MessageDto messageDto) {
            Message.Add(new MessageEntity(
                messageDto.Content,
                messageDto.TypeMessage,
                messageDto.Caption,
                messageDto.SessionName,
                messageDto.DestinationNumber,
                messageDto.FileName
            ));
            SetUpdatedAt();
        }
        public void SetName(string name){
            Name = name;
            SetUpdatedAt();
        }
        
        public void SetPhone(string phone){
            Phone = phone;
            SetUpdatedAt();
        }

        public void SetLastMessageDate(DateTime lastMessage)
        {
            LastMessageDate = lastMessage;
            SetUpdatedAt();
        }
        
        public void SetIsPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
            SetUpdatedAt();
        }

        private void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
        public void SoftRemove(){
            IsDeleted = true;
            DeletedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}