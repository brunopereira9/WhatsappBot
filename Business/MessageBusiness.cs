using System.Text;
using System.Text.Json;
using WhatsappBot.Business.Interfaces;
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

    public bool StartBotMessage(string sessionName, int numberMessage)
    {
        throw new NotImplementedException();
    }
}