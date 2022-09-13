namespace WhatsappBot.Repositories;

public class BaseRepository
{
    protected readonly HttpClient httpClient;

    public BaseRepository(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri($"{Environment.GetEnvironmentVariable("BASE_URL_WHATSAPP_API")}/");
        httpClient.Timeout = TimeSpan.FromMinutes(5);
    }
}