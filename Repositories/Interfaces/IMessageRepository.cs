using WhatsappBot.Entities;

namespace WhatsappBot.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Message GetByNumber(string number);
        void Insert(Message contact);
        bool GetEntityIsFound();
    }
}