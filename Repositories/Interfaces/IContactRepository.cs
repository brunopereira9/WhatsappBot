using WhatsappBot.Entities;

namespace WhatsappBot.Interfaces
{
    public interface IContactRepository
    {
        List<ContactEntity> GetAll();
        ContactEntity GetById(int id);
        ContactEntity GetByName(string name);
        void Insert(ContactEntity contactEntity);
        void Update(ContactEntity contactEntity);
        void Remove(ContactEntity contactEntity);
        bool ContactExists(int id);
        bool GetEntityIsFound();
    }
}