using Microsoft.EntityFrameworkCore;
using WhatsappBot.Context;
using WhatsappBot.Entities;
using WhatsappBot.Interfaces;

namespace WhatsappBot.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<ContactEntity> GetEntity(){
            return _context.Contacts;
        }

        public bool GetEntityIsFound(){
            return GetEntity() != null;
        }

        public bool ContactExists(int id){
            return (GetEntity()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public List<ContactEntity> GetAll()
        {
            return GetEntity()
                .Include(
                    product => product.Message
                        .OrderByDescending(stockConferences=>stockConferences.Id)
                        .Take(1)
                )
                .Where(product => product.IsDeleted == false)
                .ToList();
        }

        public ContactEntity GetById(int id)
        {
            return GetEntity()?
                .Include(
                    product => product.Message
                        .OrderByDescending(stockConferences=>stockConferences.Id)
                )
                .SingleOrDefault(product => product.Id == id)!;
        }

        public ContactEntity GetByName(string name)
        {
            return GetEntity()?
                .Include(
                    product => product.Message
                        .OrderByDescending(stockConferences=>stockConferences.Id)
                )
                .SingleOrDefault(product => product.Name == name)!;
        }

        public void Insert(ContactEntity contactEntity)
        {
            GetEntity().Add(contactEntity);
            _context.SaveChanges();
        }

        public void Update(ContactEntity contactEntity)
        {
            _context.Entry(contactEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(ContactEntity contactEntity)
        {
            contactEntity.SoftRemove();
            Update(contactEntity);
        }

    }
}