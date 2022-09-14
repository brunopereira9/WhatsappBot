using WhatsappBot.Entities;

namespace WhatsappBot.Business.Interfaces;

public interface IMessageBusiness
{
    bool StartBotMessage(string sessionName, int numberMessage);
}