using Microsoft.EntityFrameworkCore;
using WhatsappBot.Context;
using WhatsappBot.Entities;
using WhatsappBot.Interfaces;

namespace WhatsappBot.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<MessageEntity> GetEntity(){
            return _context.Messages;
        }

        public bool GetEntityIsFound(){
            return GetEntity() != null;
        }

        public List<MessageEntity> GetAll()
        {
            return GetEntity()
                .Where(product => product.IsDeleted == false)
                .ToList();
        }

        public MessageEntity GetByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public MessageEntity GetByNumber(int id)
        {
            throw new NotImplementedException();
            // return GetEntity()?
            //     .Include(
            //         product => product.Message
            //             .OrderByDescending(stockConferences=>stockConferences.Id)
            //     )
            //     .SingleOrDefault(product => product.Id == id)!;
        }

        public MessageEntity GetByContactId(string name)
        {
            throw new NotImplementedException();
            // return GetEntity()?
            //     .Include(
            //         product => product.Message
            //             .OrderByDescending(stockConferences=>stockConferences.Id)
            //     )
            //     .SingleOrDefault(product => product.Name == name)!;
        }

        public void Insert(MessageEntity contactEntity)
        {
            GetEntity().Add(contactEntity);
            _context.SaveChanges();
        }

    }
}