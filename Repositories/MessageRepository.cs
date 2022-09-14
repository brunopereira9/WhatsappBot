using Microsoft.EntityFrameworkCore;
using WhatsappBot.Context;
using WhatsappBot.Entities;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<Message> GetEntity(){
            return _context.Messages;
        }

        public bool GetEntityIsFound(){
            return GetEntity() != null;
        }

        public List<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public void Insert(Message contact)
        {
            GetEntity().Add(contact);
            _context.SaveChanges();
        }

    }
}