using Microsoft.EntityFrameworkCore;
using WhatsappBot.Context;
using WhatsappBot.Entities;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Contact> GetEntity(){
            return _context.Contacts;
        }

        public bool GetEntityIsFound(){
            return GetEntity() != null;
        }

        public bool ContactExists(string phone){
            return (GetEntity()?.Any(contact => contact.Phone.Equals(phone))).GetValueOrDefault();
        }
        
        public void Insert(Contact contact)
        {
            GetEntity().Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Contact contact)
        {
            contact.SoftRemove();
            Update(contact);
        }
        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contact GetByName(string name)
        {
            throw new NotImplementedException();
        }


    }
}