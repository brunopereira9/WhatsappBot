using WhatsappBot.Entities;

namespace WhatsappBot.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        int GetUnvalidatedQuantity();
        PeopleEntity GetById(int id);
        IEnumerable<PeopleEntity> GetByPhone(string phone);
        void Insert(PeopleEntity peopleEntity);
        void Update(PeopleEntity peopleEntity);
        void Remove(PeopleEntity peopleEntity);
        public PeopleEntity FirstNotValidate();
        // public Task<List<PeopleEntity>> ValidateAll();
        bool GetEntityIsFound();
    }
}