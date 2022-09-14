namespace WhatsappBot.Business.Interfaces;

public interface IMessageBusiness
{
    void StartBotMessage(string sessionName, int numberMessage);
}