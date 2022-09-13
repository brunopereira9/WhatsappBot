using System.Text;
using System.Text.Json;
using WhatsappBot.Business.Interfaces;
using WhatsappBot.Entities;
using WhatsappBot.Repositories;
using WhatsappBot.Repositories.Interfaces;

namespace WhatsappBot.Business;

public class PeopleBusiness : IPeopleBusiness
{
    private readonly IPeopleRepository _peopleRepository;
    private readonly HttpClient _httpClient;

    public PeopleBusiness(IPeopleRepository peopleRepository, IHttpClientFactory httpClientFactory)
    {
        _peopleRepository = peopleRepository;
        
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri($"{Environment.GetEnvironmentVariable("BASE_URL_WHATSAPP_API")}/");
        _httpClient.Timeout = TimeSpan.FromMinutes(5);
    }
    
    public void ValidateAt(PeopleEntity contactEntity)
    {
        throw new NotImplementedException();
    }

    public void ValidateList(List<PeopleEntity> contactEntity)
    {
        throw new NotImplementedException();
    }

    public bool ContactExists(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PeopleEntity>> ValidateAll(string sessionName)
    {
        do
        {
            try
            {
                var people = _peopleRepository.FirstNotValidate();
            
                var content = new Dictionary<string, string>
                {
                    { "sessionName", sessionName },
                    { "number", $"5567{people.Phone}" }
                };

                var json = JsonSerializer.Serialize(content);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var httpResponse = await _httpClient.PostAsync("checkNumberStatus", data);

                if (httpResponse.IsSuccessStatusCode)
                {
                    people.SetIsVerified(true);
                    _peopleRepository.Update(people);
                }
                else
                {
                    people.SetIsVerified(true);
                    _peopleRepository.Update(people);
                    _peopleRepository.Remove(people);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        } while (_peopleRepository.FirstNotValidate() is not null);
        
        return new List<PeopleEntity>();
    }

    private bool PositionValid(char number) => number switch
    {
        '9'=> true,
        '8'=> true,
        _ => false
    };
}