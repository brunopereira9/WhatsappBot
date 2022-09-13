using WhatsappBot.Entities;

namespace WhatsappBot.Interfaces
{
    public interface IMessageRepository
    {
        List<MessageEntity> GetAll();
        MessageEntity GetByNumber(string number);
        MessageEntity GetByContactId(string number);
        void Insert(MessageEntity contactEntity);
        bool GetEntityIsFound();
    }
}