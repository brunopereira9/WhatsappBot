namespace WhatsappBot.Dto
{
    public class ContactDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime LastMessageDate { get; set; }
        public bool IsDeleted { get; set; }
        public MessageDto Message { get; set; }
    }
}