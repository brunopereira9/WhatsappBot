using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using WhatsappBot.Context;
using WhatsappBot.Entities;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AppDbContext _context;
        public PeopleRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<PeopleEntity> GetEntity(){
            return _context.Peoples;
        }

        public int GetUnvalidatedQuantity()
        {
            return GetEntity().Count(people => people.IsVerified.Equals(false));
        }

        public PeopleEntity GetById(int id)
        {
            return GetEntity().SingleOrDefault(people => people.Id == id);
        }
        
        public PeopleEntity FirstNotValidate()
        {
            return GetEntity().FirstOrDefault(people => people.IsVerified.Equals(false));
        }
        
        public IEnumerable<PeopleEntity> GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public void Insert(PeopleEntity peopleEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(PeopleEntity peopleEntity)
        {
            _context.Entry(peopleEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(PeopleEntity peopleEntity)
        {
            peopleEntity.SoftRemove();
            Update(peopleEntity);
        }

        public void ValidateAt(PeopleEntity peopleEntity)
        {
            throw new NotImplementedException();
        }

        public void ValidateList(List<PeopleEntity> peopleEntity)
        {
            throw new NotImplementedException();
        }

        public bool ContactExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool GetEntityIsFound()
        {
            throw new NotImplementedException();
        }
    }
}