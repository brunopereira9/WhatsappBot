using WhatsappBot.Entities;

namespace WhatsappBot.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        int GetUnvalidatedQuantity();
        People GetById(int id);
        IEnumerable<People> GetByPhone(string phone);
        void Insert(People people);
        void Update(People people);
        void Remove(People people);
        public People FirstNotValidate();
        // public Task<List<PeopleEntity>> ValidateAll();
        bool GetEntityIsFound();
    }
}