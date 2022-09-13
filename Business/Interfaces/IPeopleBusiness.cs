using WhatsappBot.Entities;

namespace WhatsappBot.Business.Interfaces;

public interface IPeopleBusiness
{
    Task<List<PeopleEntity>> ValidateAll(string sessionName);
}