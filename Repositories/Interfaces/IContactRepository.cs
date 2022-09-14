using WhatsappBot.Entities;

namespace WhatsappBot.Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        Contact GetByName(string name);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Remove(Contact contact);
        bool ContactExists(string phone);
        bool GetEntityIsFound();
    }
}