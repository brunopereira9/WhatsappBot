using System.Text;
using System.Text.Json;
using WhatsappBot.Business.Interfaces;
using WhatsappBot.Dto;
using WhatsappBot.Entities;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Business;

public class MessageBusiness : IMessageBusiness
{
    private readonly IMessageRepository _peopleRepository;
    private readonly HttpClient _httpClient;

    public MessageBusiness(IMessageRepository peopleRepository, IHttpClientFactory httpClientFactory)
    {
        _peopleRepository = peopleRepository;
        
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri($"{Environment.GetEnvironmentVariable("BASE_URL_WHATSAPP_API")}/");
        _httpClient.Timeout = TimeSpan.FromMinutes(5);
    }

    public void StartBotMessage(string sessionName, int numberMessage)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool SendMessage(MessageDto messageDto)
    {
        try
        {

            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}