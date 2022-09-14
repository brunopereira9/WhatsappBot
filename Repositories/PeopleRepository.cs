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

        private DbSet<People> GetEntity(){
            return _context.Peoples;
        }

        public int GetUnvalidatedQuantity()
        {
            return GetEntity().Count(people => people.IsVerified.Equals(false));
        }

        public People GetById(int id)
        {
            return GetEntity().SingleOrDefault(people => people.Id == id);
        }
        
        public People FirstNotValidate()
        {
            return GetEntity().FirstOrDefault(people => people.IsVerified.Equals(false));
        }
        
        public IEnumerable<People> GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public void Insert(People people)
        {
            throw new NotImplementedException();
        }

        public void Update(People people)
        {
            _context.Entry(people).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(People people)
        {
            people.SetIsVerified(true);
            people.SoftRemove();
            Update(people);
        }

        public void ValidateAt(People people)
        {
            throw new NotImplementedException();
        }

        public void ValidateList(List<People> peopleEntity)
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