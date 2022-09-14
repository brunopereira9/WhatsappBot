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

                if (people?.Phone?.Length >= 7)
                {
                    var newPhone = $"{CompleteNumber(people.Phone.Length)}{people.Phone}";
                    var content = new Dictionary<string, string>
                    {
                        { "sessionName", sessionName },
                        { "number", newPhone }
                    };
                    
                    Console.WriteLine($"Phone: {people.Phone} | newPhone: {newPhone}");

                    var json = JsonSerializer.Serialize(content);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var httpResponse = await _httpClient.PostAsync("checkNumberStatus", data);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        people.SetPhone(newPhone);
                        people.SetIsVerified(true);
                        _peopleRepository.Update(people);
                        continue;
                    }
                }
                
                _peopleRepository.Remove(people);
                
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        } while (_peopleRepository.FirstNotValidate() is not null);
        
        return new List<PeopleEntity>();
    }

    private string CompleteNumber(int length) => length switch
    {
        11=> "55",
        8 => "55679",
        7 => "556799",
        _ => "5567"
    };
}